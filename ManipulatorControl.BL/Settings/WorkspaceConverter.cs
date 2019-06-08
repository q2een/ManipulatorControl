using Newtonsoft.Json.Converters;
using System;
using UM160CalculationLib;

namespace ManipulatorControl.BL.Settings
{
    public class WorkspaceConverter : CustomCreationConverter<IWorkspace>
    {
        public override IWorkspace Create(Type objectType)
        {
            return new LeverWorkspace(0,0,0);
        }
    }
}
