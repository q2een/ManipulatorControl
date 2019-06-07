using System;

namespace GCodeParser
{
    /// <summary>
    /// Предоставляет ошибки, происходящие во время парсинга G-кода. 
    /// </summary>
    public class GCodeException : Exception
    {
        /// <summary>
        /// Возвращает или задает строку на которой была найдена ошибка.
        /// </summary>
        public int Line{ get; set; }

        /// <summary>
        /// Предоставляет ошибки, происходящие во время парсинга G-кода. 
        /// </summary>
        /// <param name="message">Информация об ошибке</param>
        public GCodeException(string message) : base(message)
        {

        }

        /// <summary>
        /// Предоставляет ошибки, происходящие во время парсинга G-кода. 
        /// </summary>
        /// <param name="message">Информация об ошибке</param>
        /// <param name="line">Строка на которой была найдена ошибка</param>
        public GCodeException(string message, int line) : base(message)
        {
            Line = line;
        }

        /// <summary>
        /// Переопределение метода класса. 
        /// </summary>
        /// <returns>Возвращает строку, содержащую номер строки с ошибкой и  текст ошибки</returns>
        public override string ToString()
        {
            return string.Format("{0}   {1}", Line, Message);
        }
    }
}
