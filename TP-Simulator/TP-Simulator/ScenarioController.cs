using System;
using System.Windows.Forms;

namespace TP_Simulator
{
    static class ScenarioController
    {
        static SimulatorGUI GUI;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Scenario scenario = Scenario.Instance;
            GUI = new SimulatorGUI();
            scenario.SetView(GUI);
            Application.Run(GUI);
        }

        static public void Deserialize(string filename)
        {
            Scenario scenario = Scenario.Instance;
            scenario.Deserialize(filename);
        }
    }
 }

