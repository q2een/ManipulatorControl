namespace ManipulatorControl.BL
{
    /// <summary>
    /// Представляет метод, который будет обрабатывать событие изменения положения центра схвата.
    /// </summary>
    /// <param name="isRunning">Флаг, указывающий происходит ли перемещение в данный момент</param>
    /// <param name="location">Положение центра схвата</param>
    public delegate void LocationEventHandler(bool isRunning, Location location);
}
