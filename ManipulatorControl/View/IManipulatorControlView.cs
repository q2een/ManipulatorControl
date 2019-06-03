using GCodeParser;
using ManipulatorControl.BL;
using ManipulatorControl.BL.Script;
using ManipulatorControl.BL.Workspace;
using System;
using System.Collections.Generic;

namespace ManipulatorControl
{
    public interface IManipulatorControlView
    {
        bool IsHotKeyMode { get; set; }
        bool IsManualControlMode { get; set; }
        bool IsEditWorkspaceMode { get;}

        List<GCodeException> ParserErrors { get; set; }
        string[] GCodeLines { get; set; }

        void SetCurrentWorkspace(RobotWorkspace workspace);

        void SetStatusMessage(string message, bool append = false);

        void SetCurrentLocation(bool isRunning, double x, double y, double z);

        void SetCurrentPosition(LeverPosition position);

        void SetZeroPositionState(bool isXYZero, bool isZZero);

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

        void SetScriptsList(IEnumerable<MovementScript> movementScripts);
        void SetScriptQueue(IEnumerable<LeverScriptPosition> scriptPositions, int activeIndex, bool isQueueExecuting);


        event EventHandler<MovementScript> InvokeRunScript;
        event EventHandler<MovementScript> InvokeRunScriptReverse;

        event EventHandler InvokeCreateScript;
        event EventHandler InvokeScriptRename;
        event EventHandler<MovementScript> InvokeRemoveScript;

        event EventHandler<MovementScript> InvokeMoveToStartScript;
        event EventHandler<MovementScript> InvokeMoveToEndScript;

        event EventHandler<LeverScriptPosition> InvokeScriptBackTo;

        event EventHandler InvokeSetCurrentAsStart;
        event EventHandler InvokeSetCurrentAsEnd;

        event EventHandler InvokeSaveScript;
        event EventHandler InvokeCancelCreatingScript;


        event EventHandler RunGCodeInterpreter;

        event EventHandler OpenSettings;

        event EventHandler InvokeStepperAbort;
        event EventHandler InvokeStepperStop;

        event EventHandler OnViewClosing;

        event EventHandler<StepLever> ManualControlStart;
        event EventHandler<StepLever> ManualControlStop;
    }
}
