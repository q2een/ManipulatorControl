using ManipulatorControl.BL.Settings;
using System;
using System.Collections.Generic;
using UM160CalculationLib;

namespace ManipulatorControl.View
{
    public interface ISettingsView
    {
        List<StepDirName> StepDirNames { get; set; }

        List<LeverStepperSettings> LeverSteppers { get; set; }

        DesignParameters DesignParameters { get; set; }

        event EventHandler SaveSettings;

        void Show();
        void Close();
    }
}
