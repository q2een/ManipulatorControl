using System;

namespace ManipulatorControl.BL.Workspace
{
    /// <summary>
    /// Предоставляет данные собитий по изменению параметров рабочей зоны плеча.
    /// </summary>
    public class EditWorkspaceEventArgs: EventArgs
    {
        /// <summary>
        /// Возвращает или задает тип плеча.
        /// </summary>
        public LeverType LeverType { get; set; }

        /// <summary>
        /// Возвращает или задает тип изменяемого значения.
        /// </summary>
        public MovableValueTypes ValueType { get; set; }

        /// <summary>
        /// Предоставляет данные собитий по изменению параметров рабочей зоны плеча.
        /// </summary>
        /// <param name="leverType">Тип плеча</param>
        /// <param name="valueType">Тип изменяемого значения</param>
        public EditWorkspaceEventArgs(LeverType leverType, MovableValueTypes valueType)
        {
            LeverType = leverType;
            ValueType = valueType;
        }
    }
}
