﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl
{
    public class Calculation
    {
        public DesignParameters DesignParameters { get; set; }

        /// <summary>
        /// <c>Calculation</c> - Класс для получения числа импульсов, необходимых для достижения заданных координат
        /// </summary>
        /// <param name="designParams">Конструктивные параметры робота</param>
        public Calculation(DesignParameters designParams)
        {
            this.DesignParameters = designParams;
        }
       
        public double GetCurrentX()
        {
            return AnglesCalculation.GetCurrentX(DesignParameters);
        }

        public double GetCurrentY()
        {
            return AnglesCalculation.GetCurrentY(DesignParameters);
        }

        public double GetCurrentZ()
        {
            return DesignParameters.HorizontalLever.AB;
        }

        public void GetXYByABValues(double lever1Ab, double lever2Ab, out double x, out double y)
        {
            double phi1 = DesignParameters.Lever1.GetAngleByABValue(lever1Ab);
            double phi2 = DesignParameters.Lever2.GetAngleByABValue(lever2Ab);

            if (!AnglesCalculation.IsAnglesAreValid(DesignParameters, new AnglesOfRotation(phi1, phi2)))
                throw new DesignParametersException(string.Format("Невозможно достичь заданные координаты"));

            x = AnglesCalculation.GetX(DesignParameters, phi1, phi2);
            y = AnglesCalculation.GetY(DesignParameters, phi1, phi2);
        }

        public void SetCurrentCoordinates(ref double x, ref double y, ref double z)
        {
            x = AnglesCalculation.GetCurrentX(DesignParameters);
            y = AnglesCalculation.GetCurrentY(DesignParameters);
            z = DesignParameters.HorizontalLever.AB;
        }

        // валидация для парсера.
        public void CheckValues(double x, double y, double z)
        {
            // В случае некорректных данных выбросит исключение.
            AnglesCalculation.GetAngles(DesignParameters, x, y);
            PulseCalculation.GetPulsesCount(DesignParameters.HorizontalLever, z);  
        }

        public void SetNewAB(LeverType type, long stepsCount)
        {
            var lever = GetPartMovableByLeverType(type);
            var newABvalue = PulseCalculation.GetNewAB(lever, stepsCount);

            lever.AB = newABvalue;
        }

        public double GetNewAB(LeverType type, long stepsCount)
        {
            return PulseCalculation.GetNewAB(GetPartMovableByLeverType(type), stepsCount);
        }

        public long CalculateStepsByDirection(LeverType type, bool isCWDirection)
        {
            return PulseCalculation.GetPulsesCountByDirection(GetPartMovableByLeverType(type), isCWDirection);
        }

        // Максимальное и минимальное значение, для ручного управления.
        public long CalculateStepsToLeverMax(LeverType type)
        {
            return PulseCalculation.GetPulsesCountToMaxValue(GetPartMovableByLeverType(type));
        }

        public long CalculateStepsToLeverMin(LeverType type)
        {
            return PulseCalculation.GetPulsesCountToMinValue(GetPartMovableByLeverType(type));
        }

        public long CalculateStepsToLeverZero(LeverType type)
        {
            return PulseCalculation.GetPulsesCountToZeroValue(GetPartMovableByLeverType(type));
        }

        // Перемещение в ноль.
        public long CalculateStepsToAbValue(LeverType type, double ab)
        {
            return PulseCalculation.GetPulsesCountToAB(GetPartMovableByLeverType(type), ab);
        }

        // Перемещение по координатам.
        public IEnumerable<StepLever> CalculateStepLever(double x, double y, double z)
        {
            var angles = AnglesCalculation.GetAngles(DesignParameters, x, y)[0];

            yield return new StepLever(LeverType.Lever1, PulseCalculation.GetPulsesCount(DesignParameters.Lever1, angles.Phi1));
            yield return new StepLever(LeverType.Lever2, PulseCalculation.GetPulsesCount(DesignParameters.Lever2, angles.Phi2));
            yield return new StepLever(LeverType.Horizontal, PulseCalculation.GetPulsesCount(DesignParameters.HorizontalLever,z));
        }

        public IRobotLever GetPartMovableByLeverType(LeverType type)
        {
            if (type == LeverType.Horizontal)
                return DesignParameters.HorizontalLever;

            return  type == LeverType.Lever1 ? DesignParameters.Lever1 : DesignParameters.Lever2;
        }
    }
}
