using LptStepperMotorControl.Stepper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl.View
{
    public interface ISettingsView
    {
        List<StepDirName> StepDirNames { get; set; }

        List<StepperMotor> SteperMotors { get; set; }

        DesignParameters DesignParameters { get; set; }

        event EventHandler SaveSettings;

        void Show();
    }
}
