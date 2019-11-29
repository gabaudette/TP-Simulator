using System;
using System.Windows.Forms;

namespace TP_Simulator
{
    static class ScenarioController
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimulatorGUI());
        }
    }

}
