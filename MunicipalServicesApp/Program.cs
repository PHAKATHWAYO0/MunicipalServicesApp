using System;
using System.Windows.Forms;
using MunicipalServicesApp.Forms;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Application entry point. Starts the app on the Main Menu form, as
    /// required by the "Report Issues" implementation spec (Task 2).
    /// </summary>
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm());
        }
    }
}
