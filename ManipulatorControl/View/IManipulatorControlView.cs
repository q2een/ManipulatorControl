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

        List<GCodeException> ParserErrors { get; set; }
        string[] GCodeLines { get; set; }

        void SetCurrentPosition(double x, double y, double z);

        void SetZeroPositionState(CoordinateDirections direction);

        #region Редактирование / добавление / удаление рабочих зон.

        void SetRobotWorkspaceParams(RobotWorkspace workspace);
        void SetCurrentEditWorkspaceModeLeverPosition(LeverType leverType, double currentValue);
        void SetEditWorkspaceMode(bool enable, RobotWorkspace workspace, MovableValueType editValues); 
        void SetWorkspaces(IEnumerable<RobotWorkspace> workspaces, int activeWorkspaceIndex = 0);

        event EventHandler<EditWorkspaceEventArgs> OnActiveEditingLeverChanged;
        event EventHandler<EditWorkspaceEventArgs> InvokeWorkspaceValueChange;
        event EventHandler<WorkspaceEventArgs> InvokeSetActiveWorkspace;          
        event EventHandler<WorkspaceEventArgs> InvokeSetEditWorkspaceMode;  
        event EventHandler<WorkspaceEventArgs> InvokeCloseEditWorkspaceMode;
        event EventHandler<WorkspaceEventArgs> InvokeSaveWorkspaceValues;   
        event EventHandler<WorkspaceEventArgs> InvokeRemoveWorkspace;
        event EventHandler<WorkspaceEventArgs> InvokeAddWorkspace;
        event EventHandler<WorkspaceEventArgs> InvokeRenameWorkspace;

        #endregion

        event EventHandler RunGCodeInterpreter;

        event EventHandler OpenSettings;

        event EventHandler InvokeStepperAbort;
        event EventHandler InvokeStepperStop;

        event EventHandler OnViewClosing;

        event EventHandler<StepLever> ManualControlStart;
        event EventHandler<StepLever> ManualControlStop;
    }
}
