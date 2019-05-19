using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl
{
    public class Calculation
    {
        /// <summary>
        /// Конструктивные параметры робота.
        /// </summary>
        private readonly DesignParameters dp;

        public DesignParameters DesignParameters
        {
            get
            {
                return this.dp;
            }
        }

        /// <summary>
        /// <c>Calculation</c> - Класс для получения числа импульсов, необходимых для достижения заданных координат
        /// </summary>
        /// <param name="designParams">Конструктивные параметры робота</param>
        public Calculation(DesignParameters designParams)
        {
            this.dp = designParams;
        }
       
        public void SetCurrentCoordinates(ref double x, ref double y, ref double z)
        {
            x = AnglesCalculation.GetCurrentX(this.dp);
            y = AnglesCalculation.GetCurrentY(this.dp);
            z = this.dp.HorizontalLever.Workspace.AB;
        }

        // валидация для парсера.
        public void CheckValues(double x, double y, double z)
        {
            // В случае некорректных данных выбросит исключение.
          /*  AnglesCalculation.GetAngles(this.dp, x, y);
            PulseCalculation.GetPulsesCount(this.dp.HorizontalLever, z);  */
        }

        public void SetNewAB(LeverType type, long stepsCount)
        {
            var lever = GetPartMovableByLeverType(type);
            var newABvalue = PulseCalculation.GetNewAB(lever, stepsCount);

            lever.Workspace.AB = newABvalue;
            lever.AB = newABvalue;
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

        // Перемещение в ноль.
        public long CalculateStepsToAbValue(LeverType type, double ab)
        {
            return PulseCalculation.GetPulsesCountToAB(GetPartMovableByLeverType(type), ab);
        }

        // Перемещение по координатам.
        public IEnumerable<StepLever> CalculateStepLever(double x, double y, double z)
        {
            yield return new StepLever(LeverType.Lever1, Convert.ToInt64(y));
            yield return new StepLever(LeverType.Lever2, Convert.ToInt64(x));
            yield return new StepLever(LeverType.Horizontal, Convert.ToInt64(z));
            /*
            var angles = AnglesCalculation.GetAngles(this.dp, x, y)[0];

            long pulsesPhi1 = PulseCalculation.GetPulsesCount(this.dp.Lever1, angles.Phi1);

            // GetPulsesCount(180 - angles.Phi2, ref ABh2, dp.Lever2);
            long pulsesPhi2 = PulseCalculation.GetPulsesCount(this.dp.Lever2, angles.Phi2);


            yield return new StepLever(LeverType.Lever1, -PulseCalculation.GetPulsesCount(this.dp.Lever1, angles.Phi1));
            yield return new StepLever(LeverType.Lever2, -PulseCalculation.GetPulsesCount(this.dp.Lever2, angles.Phi2));
            yield return new StepLever(LeverType.Horizontal, PulseCalculation.GetPulsesCount(dp.HorizontalLever,z));*/
        }

        private IRobotLever GetPartMovableByLeverType(LeverType type)
        {
            if (type == LeverType.Horizontal)
                return this.dp.HorizontalLever;

            return  type == LeverType.Lever1 ? this.dp.Lever1 : this.dp.Lever2;
        }
    }
}
