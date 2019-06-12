using ManipulatorControl.BL;

namespace ManipulatorControl.Settings
{
    /// <summary>
    /// Предоставляет интерфейс для получения и сохранения текущего положения плеча робота.
    /// </summary>
    public interface ICurrentPositionLoader
    {
        /// <summary>
        /// Возвращает текущее положение плеча робота.
        /// </summary>
        /// <param name="leverType">Тип плеча робота</param>
        /// <returns>Возвращает текущее положение плеча</returns>
        double GetCurrentPosition(LeverType leverType);

        /// <summary>
        /// Сохраняет текущее положение плеча робота.
        /// </summary>
        /// <param name="leverType">Тип плеча робота</param>
        /// <param name="currentPosition">Текущее положение плеча</param>
        void SaveCurrentPosition(LeverType leverType, double currentPosition);
    }
}
