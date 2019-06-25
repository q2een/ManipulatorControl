namespace GCodeParser
{
    /// <summary>
    /// Предоставляет структуру, содержащую информацию о лексеме.
    /// </summary>
    public struct Lexeme
    {
        /// <summary>
        /// Возвращает наименование.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Возвращает значение.
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Возвращает тип лексемы.
        /// </summary>
        public LexemeType Type { get; private set; }

        /// <summary>
        /// Предоставляет структуру, содержащую информацию о лексеме.
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="val">Значение</param>
        /// <param name="type">Тип</param>
        public Lexeme(string name, double val, LexemeType type)
        {
            Name = name;
            Value = val;
            Type = type;
        }

        /// <summary>
        /// Предоставляет структуру, содержащую информацию о лексеме GCode-команды.
        /// </summary>
        /// <param name="name">Наименование команды</param>
        public Lexeme(string name)
        {
            Name = name;
            Value = double.NaN;
            Type = LexemeType.Command;
        }

        /// <summary>
        /// Сравнивает лексему <paramref name="lexeme"/> по наименованию с <paramref name="name"/>.
        /// </summary>
        /// <returns>Результат сравнения</returns>
        public static bool operator==(Lexeme lexeme, string name)
        {
            return lexeme.Name == name;
        }

        /// <summary>
        /// Сравнивает лексему <paramref name="lexeme"/> по наименованию с <paramref name="name"/>.
        /// </summary>
        /// <returns>Результат сравнения</returns>
        public static bool operator !=(Lexeme lexeme, string name)
        {
            return lexeme.Name != name;
        }
    }
}
