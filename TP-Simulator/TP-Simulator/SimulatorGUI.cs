using System;
using System.IO;
using System.Windows.Forms;

namespace TP_Simulator
{
    public partial class SimulatorGUI : Form
    {
        public SimulatorGUI()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "XML Files (*.xml) | *.xml";
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string filePath = openFileDialog.FileName;
                FileStream fileStream = (FileStream)openFileDialog.OpenFile();
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                ScenarioController.Deserialize(fileInfo.Name);
                fileStream.Close();
            }
        }

        private void FichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
