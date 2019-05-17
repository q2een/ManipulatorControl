using System;
using System.Linq;

namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет структуру, содержащую углы поворота плеч относительно основания манипулятора.
    /// </summary>
    public struct AnglesOfRotation
    {

        #region Свойства.

        /// <summary>
        /// Возвращает угол поворота плеча (φ1).
        /// </summary>
        public double Phi1 { get; private set; }

        /// <summary>
        /// Возвращает угол поворота плеча (φ2).
        /// </summary>
        public double Phi2 { get; private set; }

        /// <summary>
        /// Возвращает пару углов, где Phi1 = 360 - φ1, Phi2 = 360 - φ2.
        /// </summary>
        public AnglesOfRotation ReverseAngles 
        { 
            get { return new AnglesOfRotation(360 - this.Phi1, 360 - this.Phi2); } 
        }

        /// <summary>
        /// Возвращает количество углов поворота плеч относительно основания манипулятора.
        /// </summary>
        public int Length
        {
            get { return 2; }
        }

        #endregion

        #region Конструкторы.

        /// <summary>
        /// Предоставляет структуру, содержащую углы поворота плеч относительно основания манипулятора.
        /// </summary>
        /// <param name="phi1">Угол поворота плеча 1 относительно основания манипулятора</param>
        /// <param name="phi2">Угол поворота плеча 2 относительно основания манипулятора</param>
        public AnglesOfRotation(double phi1, double phi2):this()
        {
            this.Phi1 = phi1;
            this.Phi2 = phi2;
        }

        #endregion

        #region Методы.

        /// <summary>
        /// Возвращает все углы (φ1, φ2, 360 - φ1, 360 - φ2).
        /// </summary>
        /// <returns>Массив углов</returns>
        public double[] GetAllAngles() 
        {
            return ((double[])this.ReverseAngles).Concat((double[])this).ToArray();
        }

        #endregion

        #region Индексатор.

        /// <summary>
        /// Возвращает угол поворота плеча по указанному индексу. Если индекс = 0, вернет значение угла φ1.
        /// </summary>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index > 1)
                    throw new IndexOutOfRangeException();

                return index == 0 ? this.Phi1 : this.Phi2;
            }
        }

        #endregion

        #region Приведение типов.

        /// <summary>
        /// Возвращает массив, содержащий значения углов поворота φ1 и φ2.
        /// </summary>
        public static implicit operator double[](AnglesOfRotation aor) 
        { 
            return new double [] {aor.Phi1, aor.Phi2}; 
        }

        #endregion
    }

}
