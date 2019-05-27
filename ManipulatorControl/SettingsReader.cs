using LptStepperMotorControl.Stepper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UM160CalculationLib;

namespace ManipulatorControl
{
    public static class SettingsReader
    {
        public static Dictionary<string, StepDirPin> GetStepDirPins()
        {
            XDocument xdoc = XDocument.Load("Settings.xml");
            var stepDirPins = new Dictionary<string, StepDirPin>();

            foreach (var stepperMotor in xdoc.Element("Settings").Element("LPTPins").Elements("StepperMotor"))
            {
                var name = stepperMotor.Attribute("name").Value;
                var step = int.Parse(stepperMotor.Element("Step").Value);
                var dir = int.Parse(stepperMotor.Element("Dir").Value);
                var enable = int.Parse(stepperMotor.Element("Enable").Value);
                stepDirPins.Add(name, new StepDirPin(step, dir, enable));
            }

            return stepDirPins;
        }

        public static List<StepDirName> GetStepDirNames()
        {
            XDocument xdoc = XDocument.Load("Settings.xml");
            var stepDirPins = new List<StepDirName>();

            foreach (var stepperMotor in xdoc.Element("Settings").Element("LPTPins").Elements("StepperMotor"))
            {
                var name = stepperMotor.Attribute("name").Value;
                var step = int.Parse(stepperMotor.Element("Step").Value);
                var dir = int.Parse(stepperMotor.Element("Dir").Value);
                var enable = int.Parse(stepperMotor.Element("Enable").Value);
                stepDirPins.Add(new StepDirName((StepDirPinType)Enum.Parse(typeof(StepDirPinType), name), new StepDirPin(step, dir, enable)));
            }

            return stepDirPins;
        }

        public static Dictionary<string, int?> GetStepDirNamePinCollection()
        {
            XDocument xdoc = XDocument.Load("Settings.xml");
            var stepDirPins = new List<KeyValuePair<string, int?>>();

            foreach (var stepperMotor in xdoc.Element("Settings").Element("LPTPins").Elements("StepperMotor"))
            {
                var name = stepperMotor.Attribute("name").Value.ToUpper();
                stepDirPins.Add(GetNamePinPair(name, "Step", stepperMotor));
                stepDirPins.Add(GetNamePinPair(name, "Dir", stepperMotor));
                stepDirPins.Add(GetNamePinPair(name, "Enable", stepperMotor));

            }

            return stepDirPins.ToDictionary(k => k.Key, v=> v.Value);
        }

        private static KeyValuePair<string, int?> GetNamePinPair(string name, string nodeName, XElement parentNode)
        {
            int? nodeValue = null;

            int node;
            if (int.TryParse(parentNode.Element(nodeName).Value, out node))
                nodeValue = node;

            return new KeyValuePair<string, int?>(name + nodeName, nodeValue);
        }


        public static Dictionary<LeverType, StepperMotor> GetMotors()
        {
            XDocument xdoc = XDocument.Load("Stepper.xml");
            var stepDirPins = new Dictionary<LeverType, StepperMotor>();

            foreach (var stepperMotor in xdoc.Element("Settings").Element("Steppers").Elements("Stepper"))
            {
                var name = GetLeverTypeByName(stepperMotor.Attribute("name").Value);
                var isLog0 = stepperMotor.Element("IsLog0").Value == "1";
                var speed = float.Parse(stepperMotor.Element("Speed").Value);
                var acceleration = float.Parse(stepperMotor.Element("Acceleration").Value);
                stepDirPins.Add(name, new StepperMotor(null, new StepDirPin())
                                                                                {
                                                                                    MaxSpeed = speed,
                                                                                    Acceleration = acceleration,
                                                                                    CWDirectionIsLogicalZero = isLog0
                                                                                });
            }

            return stepDirPins;
        }

        private static LeverType GetLeverTypeByName(string name)
        {
            if (name == LeverType.Lever1.ToString())
                return LeverType.Lever1;

            if (name == LeverType.Lever2.ToString())
                return LeverType.Lever2;

            return LeverType.Horizontal;
        }
    }
}
