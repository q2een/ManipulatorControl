namespace UM160CalculationLib
{
    public interface IPartMovable
    {
        double ABmax { get; set; }

        double ABmin { get; set; }

        double AB { get; set; }

        /// <summary>
        /// Проверяет соответствует ли конструктивным параметрам новое значение расстояния от оси подвеса ходового винта 
        /// до точки крепления плеча к гайке ходового винта и возвращает результат проверки.
        /// </summary>
        /// <param name="newABValue">Новове значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта</param>
        /// <returns>Результат проверки нового значения на соответствие конструктивным параметрам робота</returns>
        bool IsNewABValueCorrect(double newABValue);
    }
}
