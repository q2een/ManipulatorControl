using System;

namespace ManipulatorControl.BL.Workspace
{
    /// <summary>
    /// Предоставляет возможные типы значений подвижной части плеча робота-манипулятора.
    /// </summary>
    [Flags]
    public enum MovableValueTypes
    {
        /// <summary>
        /// Не задана.
        /// </summary>
        None = 1,
        /// <summary>
        /// Максимальное значение.
        /// </summary>
        Max = 2,
        /// <summary>
        /// Минимальное значение.
        /// </summary>
        Min = 4,
        /// <summary>
        /// Нелевое положение.
        /// </summary>
        Zero = 8,
    }
}
