namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет класс с конструктивными параметрами плеча робота-манипулятора.
    /// </summary>
    public interface IRobotLever : IPartMovable
    {
        /// <summary>
        /// Возвращает или задает рабочую область плеча робота-манипулятора.
        /// </summary>
        IWorkspace Workspace { get; set; }

        /// <summary>
        /// Возвращает или задает флаг указывающий увеличивается ли значение <see cref="IPartMovable.AB"/> при движении ротора ШД по часовой стрелке.
        /// </summary>
        bool IsABIncreasesOnStepperCW { get; set; }
    }
}
