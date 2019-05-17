namespace GCodeParser
{
    public class DefaultCommandManager : ICommandManager
    {
        public virtual string[] SupportedCommands
        {
            get
            {
                return new[] { "G01", "G91", "G16", "G17", "G18", "G678", "M30" };
            }
        }


        GCodeException[] ICommandManager.ValidateCommand(string command, params Lexeme[] args)
        {
            return new[] { ValidateCommand(command, args) };
        }


        private GCodeException ValidateCommand(string command, params Lexeme[] args)
        {
            switch (command)
            {
                case "G01":
                    return CheckThreeCoordinates(args);

                case "G91":
                case "G92":
                case "G16":
                case "G17":
                case "G18":
                case "G678":
                    return CheckNoArg(args);
                case "M30":
                    return CheckNoArg(args) ?? new EndOfCodeException();

                default:
                    return new GCodeException(string.Format("Команда '{0}' не поддерживается", command));
            }
        }

        #region Проверка корректности команд.

        // Проверка наличия координат.
        private GCodeException CheckThreeCoordinates(params Lexeme[] args)
        {
            if (args.Length > 3 || args.Length == 0)
                return new GCodeException("Недопустимое количество аргументов");

            foreach (var arg in args)
            {
                if (arg.Name != "X" && arg.Name != "Y" && arg.Name != "Z")
                    return new GCodeException("Недопустимый аргумент");
            }

            return null;
        }

        // Проверка на отсутствие аргументов после команды.
        private GCodeException CheckNoArg(params Lexeme[] args)
        {
            if (args.Length != 0)
                return new GCodeException("Недопустимое количество аргументов");

            return null;
        }

        #endregion
    }
}
