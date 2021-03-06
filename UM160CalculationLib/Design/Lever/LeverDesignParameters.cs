﻿using System;

namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет класс, содержащий свойства описывающие конструктивные параметры плеча робота-манипулятора.
    /// </summary>
    public class LeverDesignParameters : RobotLever
    {
        // Множитель для перевода градусы в радианы.
        private const double deg = Math.PI / 180;

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
        /// Возвращает характеристику шагового электродвигателя, градусы.
        /// </summary>
        /// <remarks>
        /// Характеристика шагового электродвигателя - угол поворота ротора ШД
        /// за один шаг.
        /// </remarks>
        public double Ro { get; private set; }

        /// <summary>
        /// Возвращает характеристику шагового электродвигателя, радианы.
        /// </summary>
        public double RoRad
        {
            get
            {
                return Ro * deg;
            }
        }

        /// <summary>
        /// Возвращает конструктивные параметры плеча робота, градусы.
        /// </summary>
        public double Alpha { get; private set; }

        /// <summary>
        /// Возвращает конструктивные параметры плеча робота, радианы.
        /// </summary>
        public double AlphaRad
        {
            get
            {
                return Alpha * deg;
            }
        }

        /// <summary>
        /// Возвращает конструктивные параметры плеча робота, грудусы.
        /// </summary>
        public double Beta { get; private set; }

        /// <summary>
        /// Возвращает конструктивные параметры плеча робота, радианы.
        /// </summary>
        public double BetaRad
        {
            get
            {
                return Beta * deg;
            }
        }

        /// <summary>
        /// Возвращает передаточное отношение.
        /// </summary>
        public double I { get; private set; }

        /// <summary>
        /// Возвращает значение угла φ (угол поворота плеча относительно основания манипулятора), градусы.
        /// </summary>
        public double Phi
        {
            get
            {
                return GetAngleByABValue(AB);
            }
        }

        /// <summary>
        /// Возвращает максимальное допустимое значение угла φ, градусы.
        /// </summary>
        public double PhiMax
        {
            get
            {
                return GetAngleByABValue(IsABIncreasesOnStepperCW ? Workspace.ABmax : Workspace.ABmin);
            }
        }

        /// <summary>
        /// Возвращает минимальное допустимое значение угла φ, градусы.
        /// </summary>
        public double PhiMin
        {
            get
            {
                return GetAngleByABValue(IsABIncreasesOnStepperCW ? Workspace.ABmin : Workspace.ABmax);
            }
        }

        #endregion

        #region Методы.

        /// <summary>
        /// Возвращает угол поворота плеча относительно основания манипулятора на основе расстояния от оси подвеса 
        /// ходового винта до точки крепления плеча к гайке ходового винта <paramref name="ab"/>.
        /// </summary>
        /// <returns>Угол поворота плеча относительно основания манипулятора (угол φ)</returns>
        public double GetAngleByABValue(double ab)
        {
            var designAngles = (AlphaRad + BetaRad);
            var acos = Math.Acos(((AO * AO) + (BO * BO) - (ab * ab)) / (2 * AO * BO));

            var angle = IsABIncreasesOnStepperCW ? designAngles + acos : (2 * Math.PI) - designAngles - acos;

            return angle * (1.0 / deg);
        }

        /// <summary>
        /// Рассчитывает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта 
        /// в зависимости от угла поворота плеча относительно основания манипулятора.
        /// </summary>
        /// <param name="phi">Угол поворота плеча относительно основания манипулятора (угол φ), градусы</param>
        /// <returns>Расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</returns>
        public double GetABValueByAngle(double phi)
        {
            phi *= IsABIncreasesOnStepperCW ? -deg : deg;
            return Math.Round(Math.Sqrt(Math.Pow(AO, 2) + Math.Pow(BO, 2) - (2 * AO * BO * Math.Cos(AlphaRad + BetaRad + phi))), 0);
        }

        #endregion

        #region Конструкторы.

        /// <summary>
        /// Предоставляет класс, содержащий свойства описывающие конструктивные параметры плеча робота-манипулятора.
        /// </summary>
        /// <param name="ao">Расстояние между точкой подвеса плеча и ходового винта, поворачивающего плечо, мм</param>
        /// <param name="bo">Расстояние между точкой подвеса плеча и точкой его крепления к гайке ходового винта, мм</param>
        /// <param name="p">Шаг ходового винта, мм</param>
        /// <param name="ro">Характеристика шагового электродвигателя, градусы</param>
        /// <param name="alpha">Конструктивные параметры плеча робота, градусы</param>
        /// <param name="beta">Конструктивные параметры плеча робота, грудусы</param>
        /// <param name="i">Передаточное отношение</param>
        /// <param name="isABIncreasesOnStepperCW">Указывает увеличивается ли расстояни от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта при движении ротора ШД по часовой стрелке.</param>
        /// <param name="ab">Текущее расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmin">Минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmax">Максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abzero">Расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта являющееся нулевой точкой отсчета, мм</param>
        public LeverDesignParameters(double ao, double bo, double p, double ro, double alpha, double beta, double i, bool isABIncreasesOnStepperCW, double ab, double abmin, double abmax, double? abzero = null) 
            : base(isABIncreasesOnStepperCW, ab, abmin, abmax, abzero)
        {
            AO = ao;
            BO = bo;
            Alpha = alpha;
            Beta = beta;
            P = p;
            Ro = ro;
            I = i;
        }

        #endregion
    }
}
