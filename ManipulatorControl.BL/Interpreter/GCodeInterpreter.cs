using System;
using System.Collections.Generic;
using System.Linq;
using GCodeParser;

namespace ManipulatorControl.BL.Interpreter
{
    /// <summary>
    /// Предоставляет класс для интерпретации G-кода.
    /// </summary>
    public class GCodeInterpreter : ICommandManager
    {
        private readonly Calculation calculation;

        private PlaneType plane = PlaneType.XYZ;
        private CoordinateSystem coordinateSystem = CoordinateSystem.Absolute;

        private double x, y, z;

        private double X
        {
            get { return x; }
            set
            {
                if (plane == PlaneType.XY || plane == PlaneType.XZ || plane == PlaneType.XYZ)
                    x = coordinateSystem == CoordinateSystem.Absolute ? value : x + value;
            }
        }

        private double Y
        {
            get { return y; }
            set
            {
                if (plane == PlaneType.XY || plane == PlaneType.YZ || plane == PlaneType.XYZ)
                    y = coordinateSystem == CoordinateSystem.Absolute ? value : y + value;
            }
        }

        private double Z
        {
            get { return z; }
            set
            {
                if (plane == PlaneType.XZ || plane == PlaneType.YZ || plane == PlaneType.XYZ)
                    z = coordinateSystem == CoordinateSystem.Absolute ? value : z + value;
            }
        }

        /// <summary>
        /// Предоставляет класс для интерпретации G-кода.
        /// </summary>
        /// <param name="calculation">Экземпляр класса для расчета значений перемещения робота</param>
        public GCodeInterpreter(Calculation calculation)
        {
            this.calculation = calculation;

            calculation.SetCurrentCoordinates(ref x, ref y, ref z);
        }

        /// <summary>
        /// Интерпретирует очередь команд <paramref name="commands"/>.
        /// </summary>
        /// <param name="commands">Очередь команд G-кода</param>
        /// <returns>Возвращает очередь указывающую количество шагов которое необходимо выполнить ШД плеча</returns>
        public Queue<StepLever> Interprete(Queue<KeyValuePair<string, Lexeme[]>> commands)
        {
            plane = PlaneType.XYZ;
            coordinateSystem = CoordinateSystem.Absolute;

            calculation.SetCurrentCoordinates(ref x, ref y, ref z);

            var steppersQueue = new Queue<StepLever>();

            while (commands.Count > 0)
            {
                var command = commands.Dequeue();

                switch (command.Key)
                {
                    case "G01":
                        var correctCoordinates = GetCorrectCoordinates(command.Value);

                        double x = X, y = Y, z = Z;

                        UpdateXYZ(correctCoordinates);

                        var stepLevers = calculation.CalculateStepLever(x, X, y, Y, z, Z).Where(sl => sl.StepsCount != 0);

                        // Если в списке аргументов G кода координа Z идет на первом месте
                        // то сначала выполнять ее. Порядок X и Y не важен, так как они изменяются вместе.
                        if (correctCoordinates[0] == "Z")
                            stepLevers = stepLevers.OrderByDescending(lever => lever.Lever);

                        Enqueue(steppersQueue, stepLevers);

                        break;

                    case "G91":
                    case "G92":
                    case "G16":
                    case "G17":
                    case "G18":
                    case "G678":
                        SetCoordinateSystemOrPlaneType(command.Key);
                        break;

                    default: throw new NotImplementedException();
                }                               
            }

            return steppersQueue;
        }

        // Добавляет коллекцию в в очередь
        private void Enqueue(Queue<StepLever> steppersQueue, IEnumerable<StepLever> stepLevers)
        {
            foreach (var stepLever in stepLevers)
                steppersQueue.Enqueue(stepLever);
        }

        /// <summary>
        /// Задает новые значения текущих координат на основе агрументов команды <paramref name="args"/>.
        /// Учитывает текущую плоскость и абсолютную / относительную систему координат.
        /// </summary>
        private void UpdateXYZ(Lexeme[] args)
        {
            var xValue = args.SingleOrDefault(lexeme => lexeme == "X");
            var yValue = args.SingleOrDefault(lexeme => lexeme == "Y");
            var zValue = args.SingleOrDefault(lexeme => lexeme == "Z");

            if (!string.IsNullOrEmpty(xValue.Name))
                X = xValue.Value;

            if (!string.IsNullOrEmpty(yValue.Name))
                Y = yValue.Value;

            if (!string.IsNullOrEmpty(zValue.Name))
                Z = zValue.Value;
        }
       
        // Возвращает корректные аргументы команды учитывая текущую плоскость и систему координат.
        private Lexeme[] GetCorrectCoordinates(Lexeme[] args)
        { 
            if (plane == PlaneType.XY)
                return args.Where(lexeme => lexeme != "Z").ToArray();
            if (plane == PlaneType.XZ)
                return args.Where(Lexeme => Lexeme != "Y").ToArray();
            if (plane == PlaneType.YZ)
                return args.Where(Lexeme => Lexeme != "X").ToArray();

            return args;
        }

        // Устанавливает текущую плоскость и систему координат на основе заданной команды.
        private void SetCoordinateSystemOrPlaneType(string command)
        {
            switch (command)
            {
                case "G91":
                case "G92":
                    coordinateSystem = command == "G91" ? CoordinateSystem.Absolute : CoordinateSystem.Relative;
                    break;
                case "G16":
                    plane = PlaneType.XY;
                    break;
                case "G17":
                    plane = PlaneType.XZ;
                    break;
                case "G18":
                    plane = PlaneType.YZ;
                    break;
                case "G678":
                    plane = PlaneType.XYZ;
                    break;
            }
        }

        // Проверяет возможно ли достичь заданные координаты, возвращает ошибку в случае, если
        // манипулятор не сможет достич заданной точки.
        private GCodeException CheckCoordinates(Lexeme[] args)
        {
            args = GetCorrectCoordinates(args);

            if (args.Length == 0)
                return new GCodeException("Нет корректных аргументов для заданной системы координат");

            var groupedArgsCount = args.GroupBy(i => i.Name)
                                       .OrderByDescending(i => i.Count())
                                       .First()
                                       .Count();

            if (groupedArgsCount > 1)
                return new GCodeException("Аргументы не могут повторяться");

            try
            {
                UpdateXYZ(args);
                calculation.CheckValues(X,Y,Z);

                return null;
            }
            catch (Exception ex)
            {
                return new GCodeException(ex.Message);
            }
        }

        #region ICommandManager Implementation.

        /// <summary>
        /// Возвращает коллекцию поддерживаемых команд.
        /// </summary>
        string[] ICommandManager.SupportedCommands
        {
            get
            {
                return new[] { "G01", "G91", "G16", "G17", "G18", "G678", "M30" };
            }
        }

        /// <summary>
        /// Производит валидацию команды <paramref name="command"/> с заданными аргументами <paramref name="args"/> и возвращает 
        /// коллекцию ошибок (экземпляры класса <seealso cref="GCodeException"/>) в случае если команда некорректна.
        /// </summary>
        /// <returns>Коллекция ошибок при валидации команды</returns>
        GCodeException[] ICommandManager.ValidateCommand(string command, params Lexeme[] args)
        {
            var errors = new List<GCodeException>();

            switch (command)
            {
                case "G01":
                    var exceptions = CheckThreeCoordinates(args);
                    errors.AddRange(exceptions);
                    if (exceptions.Count() == 0)
                        errors.Add(CheckCoordinates(args));
                    break;

                case "G91":
                case "G92":
                case "G16":
                case "G17":
                case "G18":
                case "G678":
                    errors.Add(CheckNoArg(args));
                    SetCoordinateSystemOrPlaneType(command);

                    break;
                case "M30":
                    errors.Add(CheckNoArg(args) ?? new EndOfCodeException());
                    break;

                default:
                    errors.Add(new GCodeException(string.Format("Команда '{0}' не поддерживается", command)));
                    break;
            }

            return errors.ToArray();
        }

        #region Проверка синтаксиса команд.

        // Проверка наличия координат.
        private IEnumerable<GCodeException> CheckThreeCoordinates(params Lexeme[] args)
        {
            if (args.Length > 3 || args.Length == 0)
                yield return new GCodeException("Недопустимое количество аргументов");

            foreach (var arg in args)
            {
                if (arg.Name != "X" && arg.Name != "Y" && arg.Name != "Z")
                    yield return new GCodeException("Недопустимый аргумент");
            }
        }

        // Проверка на отсутствие аргументов после команды.
        private GCodeException CheckNoArg(params Lexeme[] args)
        {
            if (args.Length != 0)
                return new GCodeException("Недопустимое количество аргументов");

            return null;
        }

        #endregion

        #endregion
    }
}
