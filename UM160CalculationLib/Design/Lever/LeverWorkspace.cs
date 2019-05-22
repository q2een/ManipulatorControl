namespace UM160CalculationLib
{

    // TODO: проверка значений в сеттерах для ограничения минимума и максимума, возможно 
    // необходимо менять значения минимума и максимума при задании одно из параметров.
    // например: макс = 10, мин = 0. Макс задается как -10, результатом будет мин = -10, макс = 0.
    public class LeverWorkspace: IPartMovable
    {
        private double ab, abZero;

        /// <summary>
        /// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        public virtual double AB
        {
            get
            {
                return ab;
            }
            set
            {
                if (!IsNewABValueCorrect(value))
                    throw new DesignParametersException("Новое значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет установленной рабочей зоне");

                ab = value;
            }
        }

        /// <summary>
        /// Возвращает максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        public virtual double ABmax { get; set; }

        /// <summary>
        /// Возвращает минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        public virtual double ABmin { get; set; }

        public virtual double ABzero
        {
            get
            {
                return abZero;
            }
            set
            {
                if (!IsNewABValueCorrect(value))
                    throw new DesignParametersException("Новое значение расстояния нулевой точки не удовлетворяет установленной рабочей зоне");

                abZero = value;
            }
        }

        /// <summary>
        /// Проверяет соответствует ли конструктивным параметрам новое значение расстояния от оси подвеса ходового винта 
        /// до точки крепления плеча к гайке ходового винта и возвращает результат проверки.
        /// </summary>
        /// <param name="newABValue">Новове значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта</param>
        /// <returns>Результат проверки нового значения на соответствие конструктивным параметрам робота</returns>
        public virtual bool IsNewABValueCorrect(double newABValue)
        {
            return newABValue >= this.ABmin && newABValue <= this.ABmax;
        }

        public static DesignParametersException GetDesignParametersException(double ab, double abmin, double abmax, double abzero)
        {
            if (abmax < abmin)
                return new DesignParametersException("Минимально допустимое значение не может быть больше максимально допустимого значения");

            if (!(ab >= abmin && ab <= abmax))
                return new DesignParametersException("Значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет установленной рабочей зоне");

            if (!(abzero >= abmin && abzero <= abmax))
                return new DesignParametersException("Значение расстояния нулевой точки не удовлетворяет установленной рабочей зоне");

            return null;
        }

        public LeverWorkspace(double ab, double abmin, double abmax, double abzero)
        {
            var exception = GetDesignParametersException(ab, abmin, abmax, abzero);

            if (exception != null)
                throw exception;

            ABmax = abmax;
            ABmin = abmin;
            AB = ab;
            this.abZero = IsNewABValueCorrect(abZero) ? abZero : ab;
        }
    }
}
