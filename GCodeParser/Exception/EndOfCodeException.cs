using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCodeParser
{
    public class EndOfCodeException : GCodeException
    {
        public EndOfCodeException(int line) : base("", line)
        {

        }

        public EndOfCodeException() : base("")
        {

        }
    }
}
