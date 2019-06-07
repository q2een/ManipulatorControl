using System;

namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет ошибки связанные с конструктивными ограничениями или ограничениями рабочей зоны.
    /// </summary>
    public class DesignParametersException : Exception
    {
        /// <summary>
        /// Предоставляет ошибки связанные с конструктивными ограничениями или ограничениями рабочей зоны.
        /// </summary>
        /// <param name="message">сообщение, описывающее текущее исключение.</param>
        public DesignParametersException(string message):base(message)
        {

        }

        /// <summary>
        /// Предоставляет ошибки связанные с конструктивными ограничениями или ограничениями рабочей зоны.
        /// </summary>
        /// <param name="message">Сообщение об ошибке, указывающее причину создания исключения</param>
        /// <param name="innerException">Исключение, вызвавшее текущее исключение, или пустая ссылка если внутреннее исключение не задано</param>
        public DesignParametersException(string message, Exception innerException) 
            :base(message, innerException)
        {  
        }
    }
}
