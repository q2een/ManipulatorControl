namespace GCodeParser
{
    /// <summary>
    /// Предоставляет интерфейс управления командами для парсера.
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// Возвращает коллекцию поддерживаемых команд.
        /// </summary>
        string[] SupportedCommands { get; }

        /// <summary>
        /// Производит валидацию команды <paramref name="command"/> с заданными аргументами <paramref name="args"/> и возвращает 
        /// коллекцию ошибок (экземпляры класса <seealso cref="GCodeException"/>) в случае если команда некорректна.
        /// </summary>
        /// <returns>Коллекция ошибок при валидации команды</returns>
        GCodeException[] ValidateCommand(string command, params Lexeme[] args); 
    }
}
