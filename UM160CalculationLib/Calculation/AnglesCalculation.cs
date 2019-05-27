using System;
using System.Collections.Generic;
using System.Linq;

namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет класс для вычисления значений углов поворота плеча (φ1 и φ2) по координатам центра схвата.
    /// </summary>
    public sealed class AnglesCalculation
    {   
        /// <summary>
        /// Возвращает корректные пары углов поворота плеча (φ1 и φ2) по координатам центра схвата.
        /// </summary>
        /// <param name="designParams">Конструктивные параметры манипулятора</param>
        /// <param name="x">Координата х центра схвата в базовой системе координат</param>
        /// <param name="y">Координата y центра схвата в базовой системе координат</param>
        /// <returns>Коллекция структур AnglesOfRotation - Значения углов поворота плеча (φ1 и φ2)</returns>
        public static List<AnglesOfRotation> GetAngles(DesignParameters designParams, double x, double y)
        {
            var instance = new AnglesCalculation(designParams);

            var validPairs = new List<AnglesOfRotation>();
            foreach (var pair in instance.GetAnglesPairs(x, y))
                if (instance.IsRootsAreValid(pair, x, y) && IsAnglesAreValid(designParams, pair))
                    validPairs.Add(pair);

            if (validPairs.Count() == 0)
                throw new DesignParametersException(string.Format("Невозможно достичь заданные координаты X={0:f3} Y{1:f3}",x,y));

            return validPairs;
        }

        public static double GetX(DesignParameters dp, double phi1, double phi2)
        {
            return (dp.L2 * Math.Cos(phi2 * deg)) + (dp.L1 * Math.Cos(phi1 * deg));
        }

        public static double GetY(DesignParameters dp, double phi1, double phi2)
        {
            return dp.Lc + (dp.L2 * Math.Sin(phi2 * deg)) + (dp.L1 * Math.Sin(phi1 * deg));
        }

        public static double GetCurrentX(DesignParameters dp)
        {
            return GetX(dp, dp.Lever1.Phi, dp.Lever2.Phi);
        }

        public static double GetCurrentY(DesignParameters dp)
        {
            return GetY(dp, dp.Lever1.Phi, dp.Lever2.Phi);
        }

        /// <summary>
        /// Проверяет пару углов на соответствие конструктивным параметрам робота.
        /// </summary>
        /// <param name="angles">Структура. Пара углов φ1 и φ2</param>
        /// <returns>Истина, если пара углов соответствует конструктивным параметрам робота</returns>
        public static bool IsAnglesAreValid(DesignParameters dp, AnglesOfRotation angles)
        {
            var phi1 = Math.Round(angles.Phi1, 2);
            var phi2 = Math.Round(angles.Phi2, 2);

            return (phi1 >= dp.Lever1.PhiMin && phi1 <= dp.Lever1.PhiMax) &&
                (phi2 >= dp.Lever2.PhiMin && phi2 <= dp.Lever2.PhiMax);
        }

        // Множитель для перевода градусов в радианы.     
        private const double deg = Math.PI / 180.0;

        // Конструктивные параметры робота.
        private readonly DesignParameters dp;

        /// <summary>
        /// <c>AnglesCalculation</c> - Класс для вычисления значений углов поворота плеча (φ1 и φ2) по координатам центра схвата.
        /// </summary>
        /// <param name="designParams">Конструктивные параметры манипулятора</param>       
        private AnglesCalculation(DesignParameters designParams)
        {
            this.dp = designParams;
        }

        /// <summary>
        /// Возвращает структуру с парой значений угла φ2.
        /// </summary>
        /// <param name="x">Координата х центра схвата в базовой системе координат</param>
        /// <param name="y">Координата y центра схвата в базовой системе координат</param>
        /// <returns>Структура с парой значений угла φ2</returns>
        private AnglesOfRotation GetPhi2Angles(double x, double y)
        {
            double z = y - dp.Lc;
            double j = (-(dp.L1 * dp.L1) + (x * x) + (z * z) + (dp.L2 * dp.L2)) / (2 * dp.L2);

            // Значения квадратного уравнения (x^2 + z^2)*cos^2(φ2) - 2*x*j*cos(φ2) + (j^2-z^2) = 0.
            double a = (x * x) + (z * z);
            double b = -2 * x * j;
            double c = (j * j) - (z * z);

            // Корни квадратного уравнения.
            double cosf21 = (-b + Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);
            double cosf22 = (-b - Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);

            return new AnglesOfRotation(Math.Acos(cosf21) * (1 / deg), Math.Acos(cosf22) * (1 / deg));
        }

        /// <summary>
        /// Возвращает структуру с парой значений угла φ1.
        /// </summary>
        /// <param name="x">Координата х центра схвата в базовой системе координат</param>
        /// <param name="y">Координата y центра схвата в базовой системе координат</param>
        /// <returns>Структура с парой значений угла φ1</returns>
        private AnglesOfRotation GetPhi1Angles(double x, double y)
        {
            var phi2 = GetPhi2Angles(x, y);
            return new AnglesOfRotation(GetPhi1Angle(phi2.Phi1, x), GetPhi1Angle(phi2.Phi2, x));
        }

        /// <summary>
        /// Возвращает значение угла φ1 при заданном φ2.
        /// </summary>
        /// <param name="phi2">Угол φ2, градусы</param>
        /// <param name="x">Координата х центра схвата в базовой системе координат</param>
        /// <returns>Угол φ1, градусы</returns>
        private double GetPhi1Angle(double phi2, double x)
        {
            return Math.Acos(((x - (dp.L2 * Math.Cos(phi2 * deg))) / dp.L1)) * (1 / deg);
        }
        
        /// <summary>
        /// Возвращает возможные комбинации пар углов φ1 и φ2.
        /// </summary>
        /// <param name="x">Координата х центра схвата в базовой системе координат</param>
        /// <param name="y">Координата y центра схвата в базовой системе координат</param>
        /// <returns>Коллекция структур AnglesOfRotation</returns>
        private List<AnglesOfRotation> GetAnglesPairs(double x, double y)
        {
            var f1 = GetPhi1Angles(x,y).GetAllAngles();
            var f2 = GetPhi2Angles(x,y).GetAllAngles();

            var pairs = new List<AnglesOfRotation>();

            foreach(double anglef1 in f1)
            {
                foreach (double anglef2 in f2)
                    pairs.Add( new AnglesOfRotation(anglef1, anglef2));
            }

            return pairs;
        }

        /// <summary>
        /// Возвращает истину, если пара углов angles - верна.
        /// </summary>
        /// <param name="angles">Структура. Пара углов φ1 и φ2</param>
        /// <param name="x">Координата х центра схвата в базовой системе координат</param>
        /// <param name="y">Координата y центра схвата в базовой системе координат</param>
        /// <returns>true, если пара углов angles - верна</returns>
        private bool IsRootsAreValid(AnglesOfRotation angles, double x, double y)
        {
            // Переводим углы в радианы.
            var f1 = angles.Phi1 * deg;
            var f2 = angles.Phi2 * deg;
 
            // Значения х и у для данной пары углов.
            double x0 = (dp.L2 * Math.Cos(f2)) + (dp.L1 * Math.Cos(f1));
            double y0 = dp.Lc + (dp.L2 * Math.Sin(f2)) + (dp.L1 * Math.Sin(f1));

            // Проверка полученных значений с исходными (с точностью до тысячных).
            return Math.Round(x, 2) == Math.Round(x0, 2) && Math.Round(y, 2) == Math.Round(y0, 2);
        }
    }
}
