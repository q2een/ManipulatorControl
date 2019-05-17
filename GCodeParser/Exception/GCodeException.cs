using System;

namespace GCodeParser
{
    public class GCodeException : Exception
    {
        public int Line{ get; set; }

        public GCodeException(string message) : base(message)
        {

        }

        public GCodeException(string message, int line) : base(message)
        {
            Line = line;
        }

        public override string ToString()
        {
            return string.Format("{0}   {1}", Line, Message);
        }
    }
}
