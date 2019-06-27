using GCodeParser;
using ManipulatorControl.BL;
using ManipulatorControl.BL.Script;
using ManipulatorControl.BL.Workspace;
using System;
using System.Collections.Generic;

namespace ManipulatorControl.View
{
    /// <summary>
    /// Предоставляет интерфейс главного представления приложения.
    /// </summary>
    public interface IManipulatorControlView
    {
        /// <summary>
        /// Возвращает или задает ручное управление перемещением робота.
        /// </summary>
        bool IsManualControlMode { get; set; }

        /// <summary>
        /// Возвращает флаг, указывающий на редактирование рабочей зоны.
        /// </summary>
        bool IsEditWorkspaceMode { get;}

        /// <summary>
        /// Задает ошибки при интерпретации G-кода.
        /// </summary>
        List<GCodeException> ParserErrors { set; }

        /// <summary>
        /// Возвращает или задает коллекцию строк G-кода.
        /// </summary>
        string[] GCodeLines { get; set; }

        /// <summary>
        /// Задает отображение активной рабочей зоны.
        /// </summary>
        /// <param name="workspace">Активная рабочая зона</param>
        void SetCurrentWorkspace(RobotWorkspace workspace);

        /// <summary>
        /// Устанавливает сообщение с информацией о текущем действии.
        /// </summary>
        /// <param name="message">Текст сообщения о текущем действии</param>
        void SetStatusMessage(string message);

        /// <summary>
        /// Задает текущее положение центра схвата манипулятора.
        /// </summary>
        /// <param name="isRunning">Флаг, указывающий на продолжение перемещения робота</param>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="z">Координата Z</param>
        void SetCurrentLocation(bool isRunning, double x, double y, double z);

        /// <summary>
        /// Задает текущее положение плеча робота.
        /// </summary>
        /// <param name="position">Экземпляр класса, содержащий тип плеча и его положение</param>
        void SetCurrentPosition(LeverPosition position);

        /// <summary>
        /// Устанавливает нулевое положение.
        /// </summary>
        /// <param name="isXYZero">Указывает находится ли робот в нулевом положении по координатам X и Y</param>
        /// <param name="isZZero">Указывает находится ли робот в нулевом положении по координате Z</param>
        void SetZeroPositionState(bool isXYZero, bool isZZero);

        #region Редактирование / добавление / удаление рабочих зон.

        /// <summary>
        /// Отображает параметры рабочей зоны.
        /// </summary>
        /// <param name="workspace">Рабочая зона</param>
        void SetRobotWorkspaceParams(RobotWorkspace workspace);

        /// <summary>
        /// Отображает текущее положение плеча заданного типа.
        /// </summary>
        /// <param name="leverType">Тип плеча</param>
        /// <param name="currentValue">Текущее положение плеча</param>
        void SetCurrentEditWorkspaceModeLeverPosition(LeverType leverType, double currentValue);

        /// <summary>
        /// Устанвавает / выключает режим редактирования рабочей зоны.
        /// </summary>
        /// <param name="enable">Включить ли редактирование рабочей зоны</param>
        /// <param name="workspace">Рабочая зона для редактирования</param>
        /// <param name="editValues">Разрешенные для редактирования параметры</param>
        void SetEditWorkspaceMode(bool enable, RobotWorkspace workspace, MovableValueTypes editValues); 

        /// <summary>
        /// Задает список доступных рабочих зон.
        /// </summary>
        /// <param name="workspaces">Список рабочих зон</param>
        /// <param name="activeWorkspaceIndex">Индекс активной рабочей зоны</param>
        void SetWorkspaces(IEnumerable<RobotWorkspace> workspaces, int activeWorkspaceIndex = 0);

        /// <summary>
        /// Происходит при смене плеча, рабочая зона которого редактируется.
        /// </summary>
        event EventHandler<EditWorkspaceEventArgs> OnActiveEditingLeverChanged;

        /// <summary>
        /// Происходит при вызове смены ограничений рабочей зоны при ее редактировании.
        /// </summary>
        event EventHandler<EditWorkspaceEventArgs> InvokeWorkspaceValueChange;

        /// <summary>
        /// Происходит при вызове удаления нулевого положения плеча.
        /// </summary>
        event EventHandler<EditWorkspaceEventArgs> InvokeRemoveZeroPosition;

        /// <summary>
        /// Происходит при вызове установки активной рабочей зоны.
        /// </summary>
        event EventHandler<WorkspaceEventArgs> InvokeSetActiveWorkspace;    
        
        /// <summary>
        /// Происходит при вызове режима редактирования рабочей зоны.
        /// </summary>
        event EventHandler<WorkspaceEventArgs> InvokeSetEditWorkspaceMode;  

        /// <summary>
        /// Происходит при вызове отмены редактирования рабочей зоны.
        /// </summary>
        event EventHandler<WorkspaceEventArgs> InvokeCloseEditWorkspaceMode;

        /// <summary>
        /// Происходит при вызове сохранения рабочей зоны.
        /// </summary>
        event EventHandler<WorkspaceEventArgs> InvokeSaveWorkspaceValues;   

        /// <summary>
        /// Происходит при вызове удаления рабочей зоны.
        /// </summary>
        event EventHandler<WorkspaceEventArgs> InvokeRemoveWorkspace;

        /// <summary>
        /// Происходит при вызове добавления рабочей зоны. 
        /// </summary>
        event EventHandler<WorkspaceEventArgs> InvokeAddWorkspace;

        /// <summary>
        /// Происходит при вызове переименования рабочей зоны.
        /// </summary>
        event EventHandler<WorkspaceEventArgs> InvokeRenameWorkspace;

        #endregion
        
        /// <summary>
        /// Устанавливает коллекцию сценариев.
        /// </summary>
        /// <param name="movementScripts">Коллекция сценариев</param>
        void SetScriptsList(IEnumerable<MovementScript> movementScripts);

        /// <summary>
        /// Устанавливает очередь команд сценария.
        /// </summary>
        /// <param name="scriptPositions">Траектория движения робота</param>
        /// <param name="activeIndex">Индекс активной точки сценария</param>
        /// <param name="isQueueExecuting">Флаг указывающий на выполнение перемещения по точкам сценария</param>
        void SetScriptQueue(IEnumerable<LeverScriptPosition> scriptPositions, int activeIndex, bool isQueueExecuting);

        /// <summary>
        /// Устанавливает выполнение сценария.
        /// </summary>
        /// <param name="isExecuting">Выполняется ли сценарий</param>
        /// <param name="movementScript">Экземпляр класса выполняющегося сценария</param>
        void SetScriptExecuting(bool isExecuting, MovementScript movementScript);

        /// <summary>
        /// Устанавливает режим создания сценария.
        /// </summary>
        /// <param name="isCreating">Установить ли режим создания сценария</param>
        void SetScriptCreatingMode(bool isCreating);

        /// <summary>
        /// Устанавливает значения начальной или конечной точек в режиме создания сценария. 
        /// </summary>
        /// <param name="point">Точка положения робота</param>
        /// <param name="isStartPoint">Истина - точка начальная, Ложь - точка конечная</param>
        void SetScriptCreatingPoint(IEnumerable<LeverPosition> point, bool isStartPoint);

        /// <summary>
        /// Происходит при вызове действия "Выполнить сценарий".
        /// </summary>
        event EventHandler<MovementScript> InvokeRunScript;

        /// <summary>
        /// Происходит при вызове действия "Выполнить сценарий в обратном порядке".
        /// </summary>
        event EventHandler<MovementScript> InvokeRunScriptReverse;

        /// <summary>
        /// Происходит при вызове действия "Создать сценарий".
        /// </summary>
        event EventHandler<WorkspaceEventArgs> InvokeCreateScript;

        /// <summary>
        /// Происходит при вызове действия "Переименовать сценарий".
        /// </summary>
        event EventHandler<WorkspaceEventArgs> InvokeScriptRename;

        /// <summary>
        /// Происходит при вызове действия "Удалить сценарий".
        /// </summary>
        event EventHandler<MovementScript> InvokeRemoveScript;

        /// <summary>
        /// Происходит при вызове действия "Переместить в начальную точку сценария".
        /// </summary>
        event EventHandler<MovementScript> InvokeMoveToStartScript;

        /// <summary>
        /// Происходит при вызове действия "Переместить в конечную точку сценария".
        /// </summary>
        event EventHandler<MovementScript> InvokeMoveToEndScript;

        /// <summary>
        /// Происходит при вызове действия "Вернуться в ..." при создании сценария.
        /// </summary>
        event EventHandler<LeverScriptPosition> InvokeScriptBackTo;

        /// <summary>
        /// Происходит при вызове действия "Задать начальную точку" при создании сценария.
        /// </summary>
        event EventHandler InvokeSetCurrentAsStart;

        /// <summary>
        /// Происходит при вызове действия "Задать конечную точку" при создании сценария.
        /// </summary>
        event EventHandler InvokeSetCurrentAsEnd;

        /// <summary>
        /// Происходит при вызове действия "Сохранить сценарий" при создании сценария.
        /// </summary>
        event EventHandler InvokeSaveScript;

        /// <summary>
        /// Происходит при вызове действия "Отменить создание сценария" при создании сценария.
        /// </summary>
        event EventHandler InvokeCancelCreatingScript;

        /// <summary>
        /// Происходит при вызове действия "Выполнить G-код".
        /// </summary>
        event EventHandler RunGCodeInterpreter;

        /// <summary>
        /// Происходит при вызове действия "Открыть настройки".
        /// </summary>
        event EventHandler OpenSettings;

        /// <summary>
        /// Происходит при вызове действия "Прекратить перемещение".
        /// </summary>
        event EventHandler InvokeStepperAbort;

        /// <summary>
        /// Происходит при вызове действия "Остановить перемещение".
        /// </summary>
        event EventHandler InvokeStepperStop;

        /// <summary>
        /// Происходит при закрытии представления.
        /// </summary>
        event EventHandler OnViewClosing;

        /// <summary>
        /// Происходит при начале ручного управдения перемещением.
        /// </summary>
        event EventHandler<StepLever> ManualControlStart;

        /// <summary>
        /// Проихсодит при окончании ручного управления перемещением.
        /// </summary>
        event EventHandler<StepLever> ManualControlStop;
    }
}
