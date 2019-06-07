namespace GCodeParser
{
    /// <summary>
    /// Предоставляет ошибку окончания G-кода.
    /// </summary>
    public class EndOfCodeException : GCodeException
    {
        /// <summary>
        /// Предоставляет ошибку окончания G-кода.
        /// </summary>
        /// <param name="line">Номер строки ошибки</param>
        public EndOfCodeException(int line) : base("", line)
        {

        }

        /// <summary>
        /// Предоставляет ошибку окончания G-кода.
        /// </summary>
        public EndOfCodeException() : base("")
        {

        }
    }
}
