using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GCodeParser
{
    /// <summary>
    /// Предоставляет класс для преобразования Gcode текста в команды.
    /// </summary>
    public class Parser
    {
        #region Свойства.
      
        /// <summary>
        /// Вовзращает очередь команд для выполнения в случае успешной интерпретации кода.
        /// </summary>
        public Queue<KeyValuePair<string, Lexeme[]>> CommandQueue { get; private set; }

        /// <summary>
        /// Возвращает коллекцию ошибок полученных при интерпретации кода.
        /// </summary>
        public List<GCodeException> Errors { get; private set; }

        /// <summary>
        /// Возвращает объект для валидации поддерживаемых команд G кодов.
        /// </summary>
        public ICommandManager CommandManager { get; private set; }

        /// <summary>
        /// Возвращает флаг, указывающий на необходимость добавления команд в очередь.
        /// </summary>
        private bool CommandIsPersisted
        {
            get
            {
                return Errors.Count != 0;
            }
        }

        #endregion

        #region Конструкторы.

        /// <summary>
        /// Предоставляет класс для преобразования Gcode текста в команды.
        /// </summary>
        /// <param name="commandManager">Объект для валидации поддерживаемых команд G кодов</param>
        public Parser(ICommandManager commandManager)
        {
            CommandQueue = new Queue<KeyValuePair<string, Lexeme[]>>();
            Errors = new List<GCodeException>();
            CommandManager = commandManager;
        }

        #endregion

        /// <summary>
        /// Выполняет преобразование коллекции строк <paramref name="lines"/> и возвращает флаг, указывающий 
        /// на успешность выполнения преобразования.
        /// </summary>
        /// <returns>Результат преобразования: истина, если преобразование выполнено без ошибок</returns>
        public bool Parse(string[] lines)
        {
            Errors.Clear();
            CommandQueue.Clear();

            lines = lines.Select(line => RemoveComment(line.Replace(" ", ""))).ToArray();

            for (currentLineNumber = GetProgramStartIndex(lines) +1 ; currentLineNumber <= lines.Length; currentLineNumber++)
            {
                try
                {
                    ParseLine(lines[currentLineNumber - 1].ToUpper());
                }
                catch (EndOfCodeException)
                {
                    break;
                }
            }

            if (Errors.Count != 0)
                CommandQueue.Clear();

            return Errors.Count == 0;
        }

        /// <summary>
        /// Выполняет преобразование текста <paramref name="text"/> и возвращает флаг, указывающий 
        /// на успешность выполнения преобразования.
        /// </summary>
        /// <returns>Результат преобразования: истина, если преобразование выполнено без ошибок</returns>
        public bool Parse(string text)
        {
            return Parse(text.Split('\n'));
        }

        #region Парсинг строки.

        private void ParseLine(string line)
        {
            if (line == "")
                return;

            var matches = Regex.Matches(line, "[nmgxyzf][+-]?[0-9]*\\.?[0-9]*", RegexOptions.IgnoreCase).Cast<Match>();
            var parsedCommand = string.Join("", matches.Select(m => m.Value));

            if (parsedCommand != line)
                AddError("Строка имеет неверный формат");

            var lexemes = matches.Select(m => Tokenize(m.Value)).ToList();
            var commands = lexemes.Where(lexeme => lexeme.Type == LexemeType.Command);

            if (commands.Count() > 1)
                AddError("Допустима только одна команда в строке");
            if (commands.Count() < 1)
                AddError("В строке отсутствует команда");

            if (matches.Count() == 0)
                return;

            var commandLexeme = commands.First();

            lexemes.Remove(commandLexeme);

            var command = ParseCommand(commandLexeme.Name, lexemes.ToArray());

            if (!CommandIsPersisted)
                CommandQueue.Enqueue(command);
        }

        private KeyValuePair<string, Lexeme[]> ParseCommand(string command, params Lexeme[] args)
        {
            var errors = CommandManager.ValidateCommand(command, args);

            foreach (var error in errors)
            {
                if (error == null)
                    continue;

                if (error is EndOfCodeException)
                    throw error;


                error.Line = currentLineNumber;
                AddError(error);
            }

            return new KeyValuePair<string, Lexeme[]>(command, args);
        }

        private Lexeme Tokenize(string command)
        {                                  
            var type = LexemeType.Argument;
            var name = command[0].ToString();
            double val = 0;

            if (command.StartsWith("G") || command.StartsWith("M"))
            {
                type = LexemeType.Command;
                name = command;
            }  

            if (!double.TryParse(command.Substring(1), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out val))
                AddError(string.Format("Не удалось преобразовать значение аргумента '{0}' в число", command[0]));

            return new Lexeme(name, val, type);
        }

        #endregion

        #region Добавление ошибок в коллекцию.

        private void AddError(GCodeException error)
        {
            Errors.Add(error);
        }

        private void AddError(string message)
        {
            AddError(new GCodeException(message, currentLineNumber));
        }

        #endregion

        #region Подготовка исходного кода.

        // Возвращает индекс строки в которой начинается программа.
        private int GetProgramStartIndex(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "%")
                    return i + 1;
            }

            Errors.Add(new GCodeException("В коде не найдена команда начала программы"));
            return 0;
        }

        // Удаляет комментарий из строки.
        private string RemoveComment(string line)
        {
            if (line == "%")
                return line;

            var commentStartIndex = line.IndexOf("%");

            return commentStartIndex == -1 ? line : line.Substring(0, commentStartIndex);
        }

        #endregion

        #region Поля.

        private int currentLineNumber = 0;

        #endregion
    }
}
