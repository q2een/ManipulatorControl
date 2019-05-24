using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ManipulatorControl
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new MainForm();

            var presenter = new ManipulatorPresenter(view, new MessageService.MessageBoxMessageService());

            Application.Run(view);
        }
    }
}
