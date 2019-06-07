using System;

namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет класс, содержащий данные о событии изменения нулевого положения плеча робота-манипулятора.
    /// </summary>
    public class LeverZeroPositionEventArgs : EventArgs
    {
        /// <summary>
        /// Возвращает тип плеча робота-манипулятора.
        /// </summary>
        public LeverType LeverType { get; private set; }

        /// <summary>
        /// Возвращает флаг, который указывает находится ли плечо робота в нулевом положении.
        /// </summary>
        public bool IsOnZeroPosition { get; private set; }

        /// <summary>
        /// Предоставляет класс, содержащий данные о событии изменения нулевого положения плеча робота-манипулятора.
        /// </summary>
        /// <param name="leverType">Тип плеча робота-манипулятора</param>
        /// <param name="isOnZeroPosition">Флаг, который указывает находится ли плечо робота в нулевом положении</param>
        public LeverZeroPositionEventArgs(LeverType leverType, bool isOnZeroPosition)
        {
            LeverType = leverType;
            IsOnZeroPosition = isOnZeroPosition;                
        }                                                                             
    }
}
