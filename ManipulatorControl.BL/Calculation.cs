using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет класс для рассчетов значений перемещения робота. 
    /// </summary>
    public class Calculation
    {
        /// <summary>
        /// Возвращает экземпляр класса с конструктивными параметрами робота-манипулятора.
        /// </summary>
        public DesignParameters DesignParameters { get; private set; }

        /// <summary>
        /// Предоставляет класс для рассчетов значений перемещения робота. 
        /// </summary>
        /// <param name="designParams">Конструктивные параметры робота</param>
        public Calculation(DesignParameters designParams)
        {
            this.DesignParameters = designParams;
        }

        #region Координаты центра схвата.

        /// <summary>
        /// Возвращает текущее положение центра схвата по координате X.
        /// </summary>
        /// <returns>Текущее положение центра схвата по координате X</returns>
        public double GetCurrentX()
        {
            return AnglesCalculation.GetCurrentX(DesignParameters);
        }

        /// <summary>
        /// Возвращает текущее положение центра схвата по координате Y.
        /// </summary>
        /// <returns>Текущее положение центра схвата по координате Y</returns>
        public double GetCurrentY()
        {
            return AnglesCalculation.GetCurrentY(DesignParameters);
        }

        /// <summary>
        /// Возвращает текущее положение центра схвата по координате Z.
        /// </summary>
        /// <returns>Текущее положение центра схвата по координате Z</returns>
        public double GetCurrentZ()
        {
            return DesignParameters.HorizontalLever.AB;
        }

        /// <summary>
        /// Возвращает значение координат X (<paramref name="x"/>) и Y(<paramref name="y"/>) при заданном положении плеч 
        /// <paramref name="lever1Ab"/> и <paramref name="lever2Ab"/> робота - манипулятора.
        /// </summary>
        public void GetXYByABValues(double lever1Ab, double lever2Ab, out double x, out double y)
        {
            double phi1 = DesignParameters.Lever1.GetAngleByABValue(lever1Ab);
            double phi2 = DesignParameters.Lever2.GetAngleByABValue(lever2Ab);

            if (!AnglesCalculation.IsAnglesAreValid(DesignParameters, new AnglesOfRotation(phi1, phi2)))
                throw new DesignParametersException(string.Format("Невозможно достичь заданные координаты"));

            x = AnglesCalculation.GetX(DesignParameters, phi1, phi2);
            y = AnglesCalculation.GetY(DesignParameters, phi1, phi2);
        }

        /// <summary>
        /// Возвращает значение координат X (<paramref name="x"/>) и Y(<paramref name="y"/>) при перемещении плеча <paramref name="type"/>
        /// от его текущего положения на заданное количестве импульсов <paramref name="stepsCount"/>. 
        /// </summary>
        public void GetXY(LeverType type, long stepsCount, out double x, out double y)
        {
            if (type == LeverType.Horizontal)
                throw new ArgumentException();

            var newABvalue = PulseCalculation.GetNewAB(GetRobotLeverByType(type), stepsCount);

            var lever1Ab = type == LeverType.Lever1 ? newABvalue : DesignParameters.Lever1.AB;
            var lever2Ab = type == LeverType.Lever2 ? newABvalue : DesignParameters.Lever2.AB;

            GetXYByABValues(lever1Ab, lever2Ab, out x, out y);
        }

        /// <summary>
        /// Возвращает значение координаты Z при перемещении каретки робота от
        /// его текущего положения на заданное количестве импульсов <paramref name="stepsCount"/>.
        /// </summary>
        public double GetZ(long stepsCount)
        {
            return PulseCalculation.GetNewAB(DesignParameters.HorizontalLever, stepsCount);
        }

        /// <summary>
        /// Возвращает текущее положение центра схвата робота-манипулятора.
        /// </summary>
        public Location GetCurrentLocation()
        {
            return new Location()
            {
                X = GetCurrentX(),
                Y = GetCurrentY(),
                Z = GetCurrentZ()
            };
        }

        /// <summary>
        /// Возвращает положение центра схвата робота манипулятора основываясь на положение <paramref name="currentLocation"/>
        /// и заданное перемещение одного из плеч <paramref name="stepLever"/> робота-манипулятора.
        /// </summary>
        public Location GetLocation(Location currentLocation, StepLever stepLever)
        {
            if (stepLever.Lever == LeverType.Horizontal)
                return new Location(currentLocation.X, currentLocation.Y, GetZ(stepLever.StepsCount));

            double x = 0, y = 0;  
            GetXY(stepLever.Lever, stepLever.StepsCount, out x, out y);

            return new Location(x, y, currentLocation.Z);
        }

        /// <summary>
        /// Задает текущие координаты <paramref name="x"/>, <paramref name="y"/> и <paramref name="z"/> 
        /// центра схвата робота-манипулятора.
        /// </summary>
        public void SetCurrentCoordinates(ref double x, ref double y, ref double z)
        {
            x = AnglesCalculation.GetCurrentX(DesignParameters);
            y = AnglesCalculation.GetCurrentY(DesignParameters);
            z = DesignParameters.HorizontalLever.AB;
        }

        #region Парсер и интерпретатор G-кодов.

        // валидация для парсера.
        public void CheckValues(double x, double y, double z)
        {
            // В случае некорректных данных выбросит исключение.
            var a = AnglesCalculation.GetAngles(DesignParameters, x, y, 0);
            var bv = PulseCalculation.GetPulsesCount(DesignParameters.HorizontalLever, z);  
        }

        /// <summary>
        /// Возвращает коллекцию экземпляров класса <see cref="StepLever"/>, указывающий какое количество 
        /// импульсов необходимо подать на каждое из плеч робота-манипулятора для достижения координат
        /// <paramref name="x"/>, <paramref name="y"/> и <paramref name="z"/>.
        /// </summary>
        public IEnumerable<StepLever> CalculateStepLever(double x, double y, double z)
        {
            var angles = AnglesCalculation.GetAngles(DesignParameters, x, y, 0)[0];

            yield return new StepLever(LeverType.Lever1, PulseCalculation.GetPulsesCount(DesignParameters.Lever1, angles.Phi1));
            yield return new StepLever(LeverType.Lever2, PulseCalculation.GetPulsesCount(DesignParameters.Lever2, angles.Phi2));
            yield return new StepLever(LeverType.Horizontal, PulseCalculation.GetPulsesCount(DesignParameters.HorizontalLever, z));
        }

        #endregion

        #endregion

        /// <summary>
        /// Возвращает экзмеляр класса <see cref="StepLever"/>, указывающий какое количество 
        /// импульсов необходимо подать на плечо робота-манипулятора для достижения пооложения <paramref name="position"/>.
        /// </summary>
        public StepLever GetStepLeverToPosition(LeverPosition position)
        {
            return new StepLever(position.LeverType, CalculateStepsToLeverPosition(position.LeverType, position.Position));
        }

        /// <summary>
        /// Устанавливает в конструктивные параметры <see cref="DesignParameters"/> новое положения плеча <paramref name="leverType"/> исходя из 
        /// текущего положения и количества импульсов <paramref name="stepsCount"/>.
        /// </summary>
        /// <param name="leverType"></param>
        /// <param name="stepsCount"></param>
        public void SetNewLeverPosition(LeverType leverType, long stepsCount)
        {
            var lever = GetRobotLeverByType(leverType);
            var newABvalue = PulseCalculation.GetNewAB(lever, stepsCount);

            lever.AB = newABvalue;
        }

        /// <summary>
        /// Возвращает новое положения плеча <paramref name="leverType"/> исходя из текущего положения и 
        /// количества импульсов <paramref name="stepsCount"/>.
        /// </summary>
        public double GetNewLeverPosition(LeverType leverType, long stepsCount)
        {
            return PulseCalculation.GetNewAB(GetRobotLeverByType(leverType), stepsCount);
        }

        /// <summary>
        /// Возвращает количество импульсов для достижения конечного положения плеча <paramref name="leverType"/>
        /// в зависимости от движения ротора шагового двигателя. 
        /// </summary>
        public long CalculateStepsByDirection(LeverType leverType, bool isCWDirection)
        {
            return PulseCalculation.GetPulsesCountByDirection(GetRobotLeverByType(leverType), isCWDirection);
        }

        /// <summary>
        /// Возвращает количество импульсов для достижения положения <paramref name="to"/> из положения <paramref name="from"/>
        /// плеча <paramref name="leverType"/>. 
        /// </summary>
        public long CalculateSteps(LeverType leverType, double from, double to)
        {
            return PulseCalculation.GetPulsesCount(GetRobotLeverByType(leverType), from, to);
        }

        /// <summary>
        /// Возвращает количество импульсов для достижения максимального положения 
        /// плеча <paramref name="leverType"/>. 
        /// </summary>
        public long CalculateStepsToLeverMax(LeverType leverType)
        {
            return PulseCalculation.GetPulsesCountToMaxValue(GetRobotLeverByType(leverType));
        }

        /// <summary>
        /// Возвращает количество импульсов для достижения минимального положения 
        /// плеча <paramref name="leverType"/>. 
        /// </summary>
        public long CalculateStepsToLeverMin(LeverType leverType)
        {
            return PulseCalculation.GetPulsesCountToMinValue(GetRobotLeverByType(leverType));
        }

        /// <summary>
        /// Возвращает количество импульсов для достижения положения нулевой точки
        /// плеча <paramref name="leverType"/>. 
        /// </summary>
        public long CalculateStepsToLeverZero(LeverType leverType)
        {
            return PulseCalculation.GetPulsesCountToZeroValue(GetRobotLeverByType(leverType));
        }

        /// <summary>
        /// Возвращает количество импульсов необходимых для достижения положения <paramref name="position"/>
        /// плеча <paramref name="leverType"/>. 
        /// </summary>
        public long CalculateStepsToLeverPosition(LeverType leverType, double position)
        {
            return PulseCalculation.GetPulsesCountToAB(GetRobotLeverByType(leverType), position);
        }

        /// <summary>
        /// Возвращает коллекцию экземпляров класса <see cref="StepLever"/>, указывающий какое количество 
        /// импульсов необходимо подать на каждое из плеч <paramref name="levers"/> робота-манипулятора для достижения
        /// нулевой точки. 
        /// </summary>
        public IEnumerable<StepLever> StepLeversToAbZero(IEnumerable<LeverType> levers)
        {
            foreach (var leverType in levers)
                yield return new StepLever(leverType, CalculateStepsToLeverZero(leverType));
        }

        /// <summary>
        /// Возвращает экземляр класса, реализующего интерфейс <see cref="IRobotLever"/> по заданному 
        /// типу плеча <paramref name="leverType"/>.
        /// </summary>
        public IRobotLever GetRobotLeverByType(LeverType leverType)
        {
            if (leverType == LeverType.Horizontal)
                return DesignParameters.HorizontalLever;

            if (leverType == LeverType.Lever1)
                return DesignParameters.Lever1;

            if(leverType == LeverType.Lever2) 
                return DesignParameters.Lever2;

            throw new NotImplementedException("Нет реализации для заданного плеча робота");
        }
    }
}
