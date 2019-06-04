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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new MainForm();

            var presenter = new ManipulatorPresenter(view, new MessageService.MessageBoxMessageService());
             
            // Для тестирования.
            if (args.Length == 1)
                presenter.SetWorkerInterval(int.Parse(args[0]));
                            

            Application.Run(view);
        }
    }
}
