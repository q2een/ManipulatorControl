namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет интерфейс с конструктивными параметрами, отвечающими за движение плеча робота-манипулятора.
    /// </summary>
    public interface IPartMovable: IWorkspace
    {
        /// <summary>
        /// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        double AB { get; set; }
    }
}
