using GCodeParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManipulatorControl
{
    public interface IManipulatorControlView : ICoordinateDirection
    {
        bool IsHotKeyMode { get; set; }
        bool IsManualControlMode { get; set; }
        bool IsZeroPositionSet { get; set; }

        List<GCodeException> ParserErrors { get; set; }
        string[] GCodeLines { get; set; }

        event EventHandler RunGCodeInterpreter;

        event EventHandler OpenSettings;

        event EventHandler InvokeStepperAbort;
        event EventHandler InvokeStepperStop;

        event StepperMoveEventHandler ManualControlStart;
        event StepperMoveEventHandler ManualControlStop;
    }
}
