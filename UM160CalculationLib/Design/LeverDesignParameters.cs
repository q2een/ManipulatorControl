using System;
using System.Linq;

namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет класс, содержащий свойства описывающие конструктивные параметры плеча робота-манипулятора.
    /// </summary>
    public class LeverDesignParameters : IPartMovable
    {
        // Множитель для перевода градусов в радианы.
        public const double deg = Math.PI / 180;

        #region Свойства.

        /// <summary>
        /// Возвращает расстояние между точкой подвеса плеча и ходового винта, поворачивающего плечо, мм.
        /// </summary>
        public double AO { get; private set; }

        /// <summary>
        /// Возвращает расстояние между точкой подвеса плеча и точкой его крепления к гайке ходового винта, мм.
        /// </summary>
        public double BO { get; private set; }

        /// <summary>
        /// Возвращает шаг ходового винта, мм.
        /// </summary>
        public double P { get; private set; }

        /// <summary>
        /// Возвращает характеристику шагового электродвигателя.
        /// </summary>
        public double Ro { get; private set; }

        /// <summary>
        /// Возвращает конструктивные параметры плеча робота, градусы.
        /// </summary>
        public double Alpha { get; private set; }

        /// <summary>
        /// Возвращает конструктивные параметры плеча робота, грудусы.
        /// </summary>
        public double Beta { get; private set; }

        public double RoRad
        {
            get
            {
                return Ro * deg;
            }
        }

        public double AlphaRad
        {
            get
            {
                return Alpha * deg;
            }
        }

        public double BetaRad
        {
            get
            {
                return Beta * deg;
            }
        }


        private double ab, abMin, abMax;

        /// <summary>
        /// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        public double AB
        {
            get
            {
                return ab;
            }
            set
            {
                if (!IsNewABValueCorrect(value))
                    throw new DesignParametersException("Новое значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет конструктивным параметрам робота");

                ab = value;
                Phi = GetAngleByABValue(value);
            }
        }

        /// <summary>
        /// Возвращает максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        public double ABmax
        {
            get
            {
                return abMax;
            }
            set
            {
                abMax = value;
                PhiMin = GetAngleByABValue(value);
            }
        }

        /// <summary>
        /// Возвращает минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        public double ABmin
        {
            get
            {
                return abMin;
            }
            set
            {
                abMin = value;
                PhiMax = GetAngleByABValue(value);
            }
        }

        /// <summary>
        /// Возвращает значение угла φ (угол поворота плеча относительно основания манипулятора), градусы.
        /// </summary>
        public double Phi { get; private set; }

        /// <summary>
        /// Возвращает максимальное допустимое значение угла φ, градусы.
        /// </summary>
        public double PhiMax { get;  set; }

        /// <summary>
        /// Возвращает минимальное допустимое значение угла φ, градусы.
        /// </summary>
        public double PhiMin { get;  set; }

        #endregion

        #region Методы.

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

        public double GetAngleByABValue(double ab)
        {
            return ((2 * Math.PI) - (AlphaRad + BetaRad) - Math.Acos(((AO * AO) + (BO * BO) - (ab * ab)) / (2 * AO * BO))) * (1 / deg);
        }

        /// <summary>
        /// Перевод значений [градусы минуты секунды] в десятичные градусы.
        /// </summary>
        /// <param name="dms">Массив значений [градусы минуты секунды]</param>
        /// <returns>Значение в десятичных градусах</returns>
        public static double Dms2deg(double[] dms)
        {
            if (dms.Count() != 3)
                throw new Exception("Недопустимое количество элементов в массиве.");

            return dms[0] + (dms[1] / 60) + (dms[2] / (60 * 60));
        }

        #endregion

        #region Конструкторы.

        /// <summary>
        /// Конструктивные параметры плеча робота-манипулятора.
        /// </summary>
        /// <param name="AO">Расстояние между точкой подвеса плеча и ходового винта, поворачивающего плечо, мм</param>
        /// <param name="BO">Расстояние между точкой подвеса плеча и точкой его крепления к гайке ходового винта, мм</param>
        /// <param name="AB">Текущее расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmin">Минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmax">Максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="p">Шаг ходового винта, мм</param>
        /// <param name="ro">Характеристика шагового электродвигателя, градусы</param>
        /// <param name="alpha">Конструктивные параметры плеча робота, градусы</param>
        /// <param name="beta">Конструктивные параметры плеча робота, грудусы</param>
        public LeverDesignParameters(double AO, double BO, double AB, double abmin, double abmax, double p, double ro, double alpha, double beta)
        {
            this.AO = AO;
            this.BO = BO;
            this.Alpha = alpha;
            this.Beta = beta;
            this.ABmax = abmax;
            this.ABmin = abmin;
            this.AB = AB; 
            this.P = p;
            this.Ro = ro;
        }
       /*
        /// <summary>
        /// Конструктивные параметры плеча робота-манипулятора.
        /// </summary>
        /// <param name="AO">Расстояние между точкой подвеса плеча и ходового винта, поворачивающего плечо, мм</param>
        /// <param name="BO">Расстояние между точкой подвеса плеча и точкой его крепления к гайке ходового винта, мм</param>
        /// <param name="AB">Текущее расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmin">Минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmax">Максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="p">Шаг ходового винта, мм</param>
        /// <param name="ro">Характеристика шагового электродвигателя</param>
        /// <param name="alpha">Конструктивные параметры плеча робота, градусы в формате [градусы минуты секунды]</param>
        /// <param name="beta">Конструктивные параметры плеча роботаб, грудусы в формате [градусы минуты секунды]</param>
        public LeverDesignParameters(double AO, double BO, double AB, double abmin, double abmax, double p, double ro, double[] alpha, double[] beta): 
            this(AO, BO, AB, abmin, abmax, p, ro, Dms2deg(alpha), Dms2deg(beta))
        {
            
        }*/
        #endregion
    }
}
