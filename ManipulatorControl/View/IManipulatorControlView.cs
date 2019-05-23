using GCodeParser;
using ManipulatorControl.Workspace;
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
        bool IsEditWorkspaceMode { get;}

        bool IsZeroPositionSet { get; set; }

        List<GCodeException> ParserErrors { get; set; }
        string[] GCodeLines { get; set; }

        void SetRobotWorkspaceParams(RobotWorkspace workspace);

        void SetEditWorkspaceMode(bool enable, RobotWorkspace workspace, MovableValueType editValues);

        void SetWorkspaces(RobotWorkspace[] workspaces);

        event EventHandler SetWorkspaceModeChanged;
        event EventHandler<EditWorkspaceEventArgs> InvokeWorkspaceValueChange;

        event EventHandler<WorkspaceEventArgs> InvokeSetEditWorkspaceMode;
        event EventHandler<WorkspaceEventArgs> InvokeCloseEditWorkspaceMode;
        event EventHandler<WorkspaceEventArgs> InvokeSaveWorkspaceValues;

        event EventHandler RunGCodeInterpreter;

        event EventHandler OpenSettings;

        event EventHandler InvokeStepperAbort;
        event EventHandler InvokeStepperStop;

        event StepperMoveEventHandler ManualControlStart;
        event StepperMoveEventHandler ManualControlStop;
    }
}
