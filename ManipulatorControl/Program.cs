using ManipulatorControl.Settings;
using System;
using System.Windows.Forms;

namespace ManipulatorControl
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new View.MainForm();

            var presenter = new ManipulatorPresenter(view, new View.SettingsForm(), new ApplicationPropertiesCurrentPositionLoader(), new MessageService.MessageBoxMessageService());

            Application.Run(view);
        }
    }
}
