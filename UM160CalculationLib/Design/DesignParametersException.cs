using System;

namespace UM160CalculationLib
{
    public class DesignParametersException : Exception
    {
        public DesignParametersException(string message):base(message)
        {

        }

        public DesignParametersException(string message, Exception innerException) 
            :base(message, innerException)
        {  
        }
    }
}
