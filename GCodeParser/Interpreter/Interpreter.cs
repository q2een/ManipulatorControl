using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCodeParser
{
    public class Interpreter
    {
        private CoordinateSystem coordinatesSystem = CoordinateSystem.Absolute;
        private PlaneType plane = PlaneType.XYZ;
        
        public void Interpret(Queue<KeyValuePair<string, Lexeme[]>> commands)
        {
            while (commands.Count > 0)
            {
                InterpretCommand(commands.Dequeue());
            }
        }

        private void InterpretCommand(KeyValuePair<string,Lexeme[]> command)
        {
            switch(command.Key)
            {
                case "G91":
                case "G92":
                    coordinatesSystem = command.Key == "G91" ? CoordinateSystem.Absolute : CoordinateSystem.Relative;
                    break;
                case "G16":
                    plane = PlaneType.XY;
                    break;
                case "G17":
                    plane = PlaneType.XZ;
                    break;
                case "G18":
                    plane = PlaneType.YZ;
                    break;
                case "G678":
                    plane = PlaneType.XYZ;
                    break;
                case "G01":
                    Move(GetCoordinatesByContext(command.Value));
                    break;
            }
        }

        private void Move(Lexeme[] args)
        {
            
            //TODO: формирование количества импульсов и запуск
        }   

        // Возвращает необходимы аргументы команды (координаты) в зависимости
        // от контектса выполнения команды (текущей плоскости).
        private Lexeme[] GetCoordinatesByContext(Lexeme[] args)
        {
            switch(plane)
            {
                case PlaneType.XY: return args.Where(lexeme => lexeme.Name == "X" || lexeme.Name == "Y").ToArray();
                case PlaneType.XZ: return args.Where(lexeme => lexeme.Name == "X" || lexeme.Name == "Z").ToArray();
                case PlaneType.YZ: return args.Where(lexeme => lexeme.Name == "Y" || lexeme.Name == "Z").ToArray();
                default: return args;
            }
        }
    }
}
