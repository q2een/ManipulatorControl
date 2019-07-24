using GCodeParser;
using ManipulatorControl.BL.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет класс, содержащий  методы для перемещения робота-манипулятора.
    /// </summary>
    public class RobotMovement
    {
        private readonly LeverMovement leverMovement;

        private Location location;

        /// <summary>
        /// Возвращает экземпляр структуры, описывающей текущее положение центра схвата в системе координат.
        /// </summary>
        public Location Location
        {
            get
            {
                return location;
            }
            private set
            {
                location = value;
                LocationChanged(leverMovement.IsRunning, value);
            }
        }

        /// <summary>
        /// Возвращает или задает экземпляр класса для рассчетов значений перемещения плеч робота.
        /// </summary>
        public Calculation Calculation { get; set; }

        /// <summary>
        /// Возвращает конструктивные параметры робота.
        /// </summary>
        public DesignParameters DesignParameters
        {
            get
            {
                return Calculation != null ? Calculation.DesignParameters : null;
            }
        }

        /// <summary>
        /// Возвращает флаг, указывающий на выполнение перемещения робота.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return leverMovement.IsRunning;
            }
        }

        /// <summary>
        /// Происходит при изменении положения центра схвата робота-манипулятора.
        /// </summary>
        public event LocationEventHandler LocationChanged = delegate { };

        /// <summary>
        /// Происходит при изменении положения плеча робота-манипулятора.
        /// </summary>
        public event EventHandler<LeverPosition> LeverPositionChanged = delegate { };

        /// <summary>
        /// Происходит перед началом перемещения плеча робота-манипулятора.
        /// </summary>
        public event EventHandler<StepLever> OnMovingStart = delegate { };

        /// <summary>
        /// Происходит после завершения перемещения плеча робота-манипулятора.
        /// </summary>
        public event EventHandler<LeverMovingEndEventArgs> OnMovingEnd = delegate { };

        /// <summary>
        /// Происходит при смене значения положения плеча робота в нулевой точке 
        /// </summary>
        public event EventHandler<LeverZeroPositionEventArgs> OnZeroPositionChanged = delegate { };

        /// <summary>
        /// Предоставляет класс, содержащий  методы для перемещения робота-манипулятора.
        /// </summary>
        /// <param name="сalculation">Экземпляр класса для рассчета значений параметров перемещения</param>
        /// <param name="leverMovement">Экземпляр класса, отвечающий за перемещение плеч</param>
        public RobotMovement(Calculation сalculation, LeverMovement leverMovement)
        {
            Calculation = сalculation;
;

            this.leverMovement = leverMovement;

            Location = Calculation.GetCurrentLocation();

            this.leverMovement.OnMovingEnd += LeverMovement_OnMovingEnd;
            this.leverMovement.OnMovingStart += LeverMovement_OnMovingStart;
            this.leverMovement.OnStepsIntervalElapsed += LeverMovement_OnStepsIntervalElapsed;

        }

        /// <summary>
        /// Выполняет интерпретацию G-кода. В случае, если интерпретация невозможна,
        /// возвращает коллекцию ошибок - экземпляров класса <see cref="GCodeException"/>.
        /// </summary>
        /// <param name="lines">G-код</param>
        /// <returns>Eсли интерпретация невозможна - коллекция ошибок, в обратном случае - пустая коллекция</returns>
        public List<GCodeException> RunGCode(string[] lines)
        {
            var interpreter = new GCodeInterpreter(Calculation);
            var parser = new Parser(interpreter);

            var result = parser.Parse(lines);

            if (!result)
                return parser.Errors;

            var queue = interpreter.Interprete(parser.CommandQueue);

            leverMovement.Move(queue);

            return new List<GCodeException>();
        }

        /// <summary>
        /// Перемещает указанное плечо в заданное положение.
        /// </summary>
        /// <param name="leverPosition">Экземпляр класса, содержащий тип плеча и его положение</param>
        public void MoveLever(LeverPosition leverPosition)
        {
            leverMovement.Move(Calculation.GetStepLeverToPosition(leverPosition));
        }

        /// <summary>
        /// Последовательно выполняет перемещения плеч из коллекции. После завершения перемещения выполняет <paramref name="doAfter"/>.
        /// </summary>
        /// <param name="leverPositions">Коллекция экземпляров класса, который содержит тип плеча и его положение</param>
        /// <param name="doAfter">Метод, который будет выполнен после завершения перемещения</param>
        public void MoveRobotByPath(IEnumerable<LeverPosition> leverPositions, Action doAfter)
        {
            var queue = new Queue<StepLever>();   
            var currentPositions = GetCurrentLeversPosition().ToList();

            foreach (var leverPosition in leverPositions)
            {
                var nowAt = currentPositions.Single(position => position.LeverType == leverPosition.LeverType);

                var stepLever = new StepLever(leverPosition.LeverType, Calculation.CalculateSteps(leverPosition.LeverType, nowAt.Position, leverPosition.Position));
                queue.Enqueue(stepLever);

                nowAt.Position = leverPosition.Position;
            }
             
            leverMovement.Move(queue, doAfter);
        }

        /// <summary>
        /// Запускает перемещение плеча робота в ручном режиме управления.
        /// </summary>
        /// <param name="stepLever">Тип перемещаемого плеча и количество импульсов</param>
        public void ManulControlRun(StepLever stepLever)
        {
            if (leverMovement.IsRunning)
                return;
         
             if (stepLever.StepsCount == 0)
                 stepLever.StepsCount = Calculation.CalculateStepsToLeverZero(stepLever.Lever);
             else
                 stepLever.StepsCount = Calculation.CalculateStepsByDirection(stepLever.Lever, stepLever.StepsCount == 1);

            leverMovement.Move(stepLever);
        }

        /// <summary>
        /// Прекращает перемещение плеча робота в ручном режиме управления.
        /// </summary>
        /// <param name="type">Тип перемещаемого плеча</param>
        public void ManualControlStop(LeverType type)
        {
            leverMovement.Stop(type);
        }

        /// <summary>
        /// Прекращает перемещение плеча. Останавливает его с заданным торможением.
        /// </summary>
        public void Stop()
        {
            leverMovement.Stop();
        }

        /// <summary>
        /// Прерывает перемещение плеча.
        /// </summary>
        public void Abort()
        {
            leverMovement.Abort();
        }

        /// <summary>
        /// Задает интервал импульсов, после подачи которых происходит событие <see cref="LeverMovement.OnStepsIntervalElapsed"/>.
        /// </summary>
        /// <param name="interval">Число импульсов</param>
        public void SetStepsInterval(int interval)
        {
            leverMovement.StepsInterval = interval;
        }

        /// <summary>
        /// Возвращает положение плеча робота-манипулятора заданного типа <paramref name="type"/>.
        /// </summary>
        /// <param name="type">Тип плеча робота</param>
        /// <returns>Положение плеча</returns>
        public double GetLeverPosition(LeverType type)
        {
            return Calculation.GetRobotLeverByType(type).AB;
        }

        /// <summary>
        /// Возвращает положение плеча.
        /// </summary>
        /// <param name="type">Тип плеча</param>
        /// <returns>Положение плеча</returns>
        public LeverPosition GetCurrentLeverPosition(LeverType type)
        {
            return new LeverPosition(type, GetLeverPosition(type));
        }

        /// <summary>
        /// Возвращает коллекцию положений каждого плеча робота.
        /// </summary>
        /// <returns>Коллекция положений плеч робота</returns>
        public IEnumerable<LeverPosition> GetCurrentLeversPosition()
        {
            return new[]
            {
                GetCurrentLeverPosition(LeverType.Horizontal),
                GetCurrentLeverPosition(LeverType.Lever1),
                GetCurrentLeverPosition(LeverType.Lever2)
            };
        }

        /// <summary>
        /// Возвращает истину, если текущее положение робота-манипулятора соответствует 
        /// положению <paramref name="position"/>.
        /// </summary>
        /// <param name="position">Положение каждого плеча робота</param>
        /// <returns>Истина, если текущее положение соответствует положению <paramref name="position"/></returns>
        public bool IsNowAtPosition(IEnumerable<LeverPosition> position)
        {
            var current = GetCurrentLeversPosition().OrderBy(i => i.LeverType);
            position = position.OrderBy(i => i.LeverType);

            return current.SequenceEqual(position);
        }

        /// <summary>
        /// Возвращает истину если плечо робота типа <paramref name="type"/> 
        /// находится в нулевой точке рабочей зоны плеча.
        /// </summary>
        /// <param name="type">Тип плеча</param>
        /// <returns>Истина, если плечо в нулевой точке</returns>
        public bool IsOnZeroPosition(LeverType type)
        {
            var lever = Calculation.GetRobotLeverByType(type);

            return lever.Workspace.ABzero == lever.AB;
        }

        /// <summary>
        /// Проверяет, соответствует ли положения <paramref name="positions"/> плеч конструктивным параметрам или рабочей зоне. 
        /// </summary>
        /// <returns>Коллекция ошибок</returns>
        public IEnumerable<DesignParametersException> ValidateLeverPositions(IEnumerable<LeverPosition> positions)
        {
            foreach (var position in positions)
            {
                if (!Calculation.GetRobotLeverByType(position.LeverType).Workspace.IsBetweenMinAndMax(position.Position))
                    yield return new DesignParametersException(position.LeverType.ToRuString() + ": Положение " + position.Position + 
                        " не удовлетворяет конструктивным параметрам робота-манипулятора или рабочей зоне");
            }            
        }

        /// <summary>
        /// Обновляет текущее положение центра схвата в системе координат.
        /// </summary>
        public void UpdateLocation()
        {
            Location = Calculation.GetCurrentLocation();
        }

        private void ChangeLeverPosition(LeverType type, long stepsCount)
        {
            var lever = Calculation.GetRobotLeverByType(type);

            var oldValue = lever.AB;

            Calculation.SetNewLeverPosition(type, stepsCount);

            UpdateLocation();

            var newValue = lever.AB;

            LeverPositionChanged(this, new LeverPosition(type, newValue));

            if (lever.Workspace.ABzero == null)
                return;

            if(oldValue == lever.Workspace.ABzero || newValue == lever.Workspace.ABzero)
              OnZeroPositionChanged(this, new LeverZeroPositionEventArgs(type, newValue == lever.Workspace.ABzero));
        }

        private void LeverMovement_OnStepsIntervalElapsed(object sender, StepLever e)
        {
            Location = Calculation.GetLocation(Location, e);
        }

        private void LeverMovement_OnMovingStart(object sender, StepLever e)
        {
            OnMovingStart(this, e);
        }

        private void LeverMovement_OnMovingEnd(object sender, LeverMovingEndEventArgs e)
        {
            ChangeLeverPosition(e.Lever, e.StepsCount);
            OnMovingEnd(this, e);
        }
    }
}
