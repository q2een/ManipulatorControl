namespace GCodeParser
{
    /// <summary>
    /// Предоставляет перечисление типво лексем.
    /// </summary>
    public enum LexemeType
    {
        /// <summary>
        /// Текст.
        /// </summary>
        Text,
        /// <summary>
        /// Управляющая команда.
        /// </summary>
        Command,
        /// <summary>
        /// Комментарий.
        /// </summary>
        Comment,
        /// <summary>
        /// Аргумент.
        /// </summary>
        Argument
    }
}
