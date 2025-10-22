using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystemOperation.Device;

namespace VisionSystemOperation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Prevention of duplication
            bool flagMutex = false;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "VisionOperationSystem", out flagMutex);
            if (!flagMutex)

            {
                MessageBox.Show("Running Vision Program.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process.GetCurrentProcess().PriorityBoostEnabled = true;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            Machine.Initialize();
            Application.Run(new FormMdi());
        }
    }
}
