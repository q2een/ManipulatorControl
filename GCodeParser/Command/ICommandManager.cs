using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCodeParser
{
    public interface ICommandManager
    {
        string[] SupportedCommands { get; }

        GCodeException[] ValidateCommand(string command, params Lexeme[] args); 
    }
}
