﻿using System;

namespace UM160CalculationLib
{
    public interface IPartMovable: ICloneable
    {
        ///// <summary>
        ///// Возвращает максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        ///// </summary>
        double ABmax { get; set; }

        ///// <summary>
        ///// Возвращает минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        ///// </summary>
        double ABmin { get; set; }

        ///// <summary>
        ///// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        ///// </summary>
        double AB { get; set; }

        /// <summary>
        /// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, которое является нулевой точкой отсчета, мм.
        /// </summary>
        double ABzero { get; set; }

        /// <summary>
        /// Проверяет соответствует ли конструктивным параметрам новое значение расстояния от оси подвеса ходового винта 
        /// до точки крепления плеча к гайке ходового винта и возвращает результат проверки.
        /// </summary>
        /// <param name="newABValue">Новове значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта</param>
        /// <returns>Результат проверки нового значения на соответствие конструктивным параметрам робота</returns>
        bool IsNewABValueCorrect(double newABValue);
    }
}
