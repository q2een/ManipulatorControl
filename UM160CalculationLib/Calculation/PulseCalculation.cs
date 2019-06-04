﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет класс для вычисления числа импульсов, необходимых для достижения угла. 
    /// </summary>
    public static class PulseCalculation
    {
        // Множитель для перевода градусов в радианы.     
        private const double deg = Math.PI / 180.0;

        #region Публичные методы.
         
        public static long GetPulsesCount(IRobotLever lever, double param)
        {
            if (lever is LeverDesignParameters)
                return GetPulsesCount(lever as LeverDesignParameters, param);

            if (lever is HorizontalLeverDesignParameters)
                return GetPulsesCount(lever as HorizontalLeverDesignParameters, param);

            throw new Exception("Расчеты для данного экземпляра не реализованы");
        }

        /// <summary>
        /// Возвращает число импульсов, выдаваемых УЧПУ.
        /// </summary>
        /// <param name="ldp">Конструктивные параметры плеча робота-манипулятора</param>>
        /// <param name="phi">Угол поворота плеча, градусы</param>
        /// <returns>Число импульсов</returns>
        public static long GetPulsesCount(LeverDesignParameters ldp, double phi)
        {
            long pulsesCount = CalculatePulsesCount(ldp, phi);

            if (!IsPulsesCountCorrect(ldp, pulsesCount))
                throw new DesignParametersException("Конструктивные параметры робота-манипулятора (или рабочая зона) не позволяют достичь заданный угол");

            return pulsesCount;
        }

        /// <summary>
        /// Возвращает число импульсов, выдаваемых УЧПУ, которое необходимо для достижения точки <paramref name="newValue"/>
        /// плеча <paramref name="lever"/> робота-манипулятора.
        /// </summary>
        public static long GetPulsesCount(HorizontalLeverDesignParameters lever, double newValue)
        {
            if (!lever.Workspace.IsBetweenMinAndMax(newValue))
                throw new DesignParametersException("Новое значение координаты Z не удовлетворяет конструктивным параметрам робота или рабочей зоны");

            var stepsCount = ((newValue - lever.AB) * lever.Coefficient);

            return Convert.ToInt64(stepsCount) * (lever.IsABIncreasesOnStepperCW ? 1 : -1);
        }
        
        public static double GetNewAB(IRobotLever lever, long pulsesCount)
        {
            if (lever is LeverDesignParameters)
                return GetNewAB(lever as LeverDesignParameters, pulsesCount);

            if (lever is HorizontalLeverDesignParameters)
                return GetNewAB(lever as HorizontalLeverDesignParameters, pulsesCount);

            throw new Exception("Расчеты для данного экземпляра не реализованы");
        }
       
        /// <summary>
        /// Рассчитывает значение AB в зависимости от числа импульсов и текущего значения AB.
        /// </summary>
        /// <param name="ldp">Конструктивные параметры плеча робота-манипулятора</param>
        /// <param name="pulsesCount">Число импульсов</param>
        /// <returns>Новое значение ABh</returns>
        public static double GetNewAB(LeverDesignParameters ldp, long pulsesCount)
        {
            double newValue = CalculateAB(ldp, pulsesCount);

            if (!ldp.Workspace.IsBetweenMinAndMax(newValue))
                throw new DesignParametersException("Новое значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет конструктивным параметрам робота или рабочей зоны");

            return newValue;
        }

        public static double GetNewAB(HorizontalLeverDesignParameters lever, long pulsesCount)
        {
            double newValue = Math.Round(lever.AB + ((lever.IsABIncreasesOnStepperCW ? 1 : -1) * (pulsesCount / lever.Coefficient)), 0);

            if (!lever.Workspace.IsBetweenMinAndMax(newValue))
                throw new DesignParametersException("Новое значение координаты Z не удовлетворяет конструктивным параметрам робота или рабочей зоны");

            return newValue;
        }

        public static long GetPulsesCountToAB(IRobotLever lever, double ab)
        {
            if (lever is HorizontalLeverDesignParameters)
                return GetPulsesCount(lever as HorizontalLeverDesignParameters, ab);

            if (lever is LeverDesignParameters)
            {
                var lvr = lever as LeverDesignParameters;
                return GetPulsesCount(lvr, lvr.GetAngleByABValue(ab));
            }

            throw new Exception("Расчеты для данного экземпляра не реализованы");
        }
         
        public static long GetPulsesCountByDirection(IRobotLever lever, bool isCWDirection)
        {
            var target = lever.IsABIncreasesOnStepperCW && isCWDirection ? lever.Workspace.ABmax : lever.Workspace.ABmin;

            if (!lever.IsABIncreasesOnStepperCW && !isCWDirection)
                target = lever.Workspace.ABmax;

            return GetPulsesCountToAB(lever, target);
        }

        public static long GetPulsesCountToMaxValue(IRobotLever lever)
        {
            return GetPulsesCountToAB(lever, lever.Workspace.ABmax);
        }

        public static long GetPulsesCountToZeroValue(IRobotLever lever)
        {
            if (lever.Workspace.ABzero == null)
                throw new DesignParametersException("Нулевая точка не задана");

            return GetPulsesCountToAB(lever, (double)lever.Workspace.ABzero);
        }

        public static long GetPulsesCountToMinValue(IRobotLever lever)
        {
            return GetPulsesCountToAB(lever, lever.Workspace.ABmin);
        }

        #endregion

        #region Private методы.

        /// <summary>
        /// Рассичтывает число импульсов, необходимых для достижения угла phi.
        /// </summary>
        /// <param name="ldp">Конструктивные параметры плеча робота-манипулятора</param>
        /// <param name="phi">Угол поворота плеча, градусы</param>
        /// <returns>Число импульсов</returns>
        private static long CalculatePulsesCount(LeverDesignParameters ldp, double phi)
        {
            phi *= ldp.IsABIncreasesOnStepperCW ? -deg : deg;
            double pulsesCount = ldp.IsABIncreasesOnStepperCW ? -1 : 1;
            pulsesCount *= (1.0 / ldp.I) * ((ldp.AB - Math.Sqrt(Math.Pow(ldp.AO, 2) + Math.Pow(ldp.BO, 2) - (2 * ldp.AO * ldp.BO * Math.Cos(ldp.AlphaRad + ldp.BetaRad + phi)))) / (ldp.P * ldp.RoRad));

            return Convert.ToInt64(pulsesCount);
        }

        /// <summary>
        /// Возвращает истину если pulsesCount допустимое значение.
        /// </summary>
        /// <param name="ldp">Конструктивные параметры плеча робота-манипулятора</param>
        /// <param name="pulsesCount">Число импульсов</param> 
        /// <returns>Истина, если pulsesCount допустимое значение</returns>
        private static bool IsPulsesCountCorrect(LeverDesignParameters ldp, long pulsesCount)
        {
            return ldp.Workspace.IsBetweenMinAndMax(CalculateAB(ldp, pulsesCount));
        }

        /// <summary>
        /// Рассчитывает значение AB в зависимости от числа импульсов и текущего значения AB.
        /// </summary>
        /// <param name="ldp">Конструктивные параметры плеча робота-манипулятора</param>
        /// <param name="pulsesCount">Число импульсов</param> 
        /// <returns>Новое значение AB</returns>
        private static double CalculateAB(LeverDesignParameters ldp, long pulsesCount)
        {
            pulsesCount = ldp.IsABIncreasesOnStepperCW ? pulsesCount : -pulsesCount;
            // Округляем сотые значение миллиментов.
            return Math.Round(ldp.AB + (ldp.RoRad * pulsesCount * ldp.I * ldp.P), 0);
        }

        #endregion

    }
}
