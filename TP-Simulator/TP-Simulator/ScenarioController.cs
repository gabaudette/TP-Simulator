using System;
using System.Windows.Forms;

namespace TP_Simulator
{
    static class ScenarioController
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimulatorGUI());
        }

        static public void Deserialize(string filename)
        {
            Scenario.Deserialize(filename);
        }
    }
 }

