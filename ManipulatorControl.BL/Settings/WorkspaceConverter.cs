using Newtonsoft.Json.Converters;
using System;
using UM160CalculationLib;

namespace ManipulatorControl.BL.Settings
{
    /// <summary>
    /// Предоставляет конвертер для сериализации и десериализации.
    /// </summary>
    public class WorkspaceConverter : CustomCreationConverter<IWorkspace>
    {
        /// <summary>
        /// Созадает объект <see cref="LeverWorkspace"/>. 
        /// </summary>
        /// <param name="objectType">Тип объекта</param>
        /// <returns>Объект LeverWorkspace</returns>
        public override IWorkspace Create(Type objectType)
        {
            return new LeverWorkspace(0,0,0);
        }
    }
}
