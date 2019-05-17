﻿using LptStepperMotorControl.Stepper;
using UM160CalculationLib;

namespace ManipulatorControl
{
    public class RobotLever
    {
        public LeverType Type { get; private set; }

        public StepperMotor Stepper { get; private set; }

        public CoordinateDirections OnCWDirections { get; private set; }

        public CoordinateDirections OnCCWDirections { get; private set; }

        public CoordinateDirections ActiveDirection
        {
            get
            {
                return Stepper.Direction == Direction.CW ? OnCWDirections : OnCCWDirections;
            }
        }

        public RobotLever(LeverType type, StepperMotor stepper, CoordinateDirections onCW, CoordinateDirections onCCW)
        {
            Type = type;
            Stepper = stepper;
            OnCWDirections = onCW;
            OnCCWDirections = onCCW;
        }
    }
}
