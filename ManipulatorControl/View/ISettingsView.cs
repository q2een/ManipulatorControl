using ManipulatorControl.BL.Settings;
using System;
using System.Collections.Generic;
using UM160CalculationLib;

namespace ManipulatorControl.View
{
    /// <summary>
    /// Предоставляет интерфейс представления изменения параметров приложения.
    /// </summary>
    public interface ISettingsView
    {
        /// <summary>
        /// Возвращает или задает коллекцию PIN для подключения платы драйверов ШД.
        /// </summary>
        List<StepDirName> StepDirNames { get; set; }

        /// <summary>
        /// Возвращает или задает коллекцию параметров шаговых двигателей.
        /// </summary>
        List<LeverStepperSettings> LeverSteppers { get; set; }

        /// <summary>
        /// Возвращает или задает конструктивные параметры робота-манипулятора.
        /// </summary>
        DesignParameters DesignParameters { get; set; }

        /// <summary>
        /// Происходит при сохранении параметров пользователем.
        /// </summary>
        event EventHandler SaveSettings;

        /// <summary>
        /// Отображает текущее представление.
        /// </summary>
        void Show();

        /// <summary>
        /// Закрывает текущее представление.
        /// </summary>
        void Close();
    }
}
