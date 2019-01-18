using System;
using System.Windows.Forms;
using WorkoutTracker.View;

namespace WorkoutTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainWindow = new MainWindow();
            Application.Run(mainWindow);
            
        }
    }
}
