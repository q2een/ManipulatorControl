using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UM160CalculationLib
{
    public class HorizontalLeverDesignParameters : IPartMovable
    {
        public double ABmax { get; set; }

        public double ABmin { get; set; }

        private double ab;

        public double AB
        {
            get { return ab; }
            set
            {
                if (!IsNewABValueCorrect(value))
                    throw new DesignParametersException("Новое значение координаты Z не удовлетворяет конструктивным параметрам робота");

                ab = value;
            }
        }

        public double Coefficient { get; set; }

        public HorizontalLeverDesignParameters(double ab, double abMin, double abMax, double coefficient)
        {
            Coefficient = coefficient;
            ABmax = abMax;
            ABmin = abMin;
            AB = ab;
        }

        /// <summary>
        /// Проверяет соответствует ли конструктивным параметрам новое значение расстояния от оси подвеса ходового винта 
        /// до точки крепления плеча к гайке ходового винта и возвращает результат проверки.
        /// </summary>
        /// <param name="newABValue">Новове значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта</param>
        /// <returns>Результат проверки нового значения на соответствие конструктивным параметрам робота</returns>
        public bool IsNewABValueCorrect(double newABValue)
        {
            return newABValue >= this.ABmin && newABValue <= this.ABmax;
        }
    }
}
