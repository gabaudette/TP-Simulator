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

            picAircraft.BringToFront();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "XML Files (*.xml) | *.xml";
            //openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                ScenarioController.Deserialize(fileInfo.FullName);
            }
        }

        private void fillLsvAirport(int airportList){ // param est vraiment tres temporaire

            lsvAirport.Clear();

            lsvAirport.View = View.Details;

            //Ajoute les colonnes
            lsvAirport.Columns.Add("Nom");
            lsvAirport.Columns.Add("Longitude");
            lsvAirport.Columns.Add("Lattitude");


            //Remplis les colonnes
            lsvAirport.Columns[0].Width = 110;
            lsvAirport.Columns[1].Width = 40;
            lsvAirport.Columns[2].Width = 40;

            /*
            //Remplis les données
            for (int i = 0; i < airportList.Count; i++)
            {
                lsvAirport.Items.Add(new ListViewItem(new string[] {  inséré donnée ici  }));
            }
            */
        }

        private void fillLsvAircraft(int aircraftList)
        {
            lsvAircraft.Clear();

            lsvAircraft.View = View.Details;

            //Ajoute les colonnes
            lsvAircraft.Columns.Add("Nom");
            lsvAircraft.Columns.Add("Type");
            lsvAircraft.Columns.Add("Destination"); // ??
            lsvAircraft.Columns.Add("États");


            //Remplis les colonnes
            lsvAircraft.Columns[0].Width = 110;
            lsvAircraft.Columns[1].Width = 40;
            lsvAircraft.Columns[2].Width = 40;
            lsvAircraft.Columns[2].Width = 40;

            /*
            //Remplis les données
            for (int i = 0; i < aircraftList.Count; i++)
            {
                lsvAirport.Items.Add(new ListViewItem(new string[] { inséré donnée ici }));
            }*/
        }

        private void fillLsvClients()
        {
            lsvClient.Clear();

            lsvClient.View = View.Details;

            //Ajoute les colonnes
            lsvClient.Columns.Add("Nombre");
            lsvClient.Columns.Add("Type");
            lsvClient.Columns.Add("Destination");


            //Remplis les colonnes
            lsvAircraft.Columns[0].Width = 110;
            lsvAircraft.Columns[1].Width = 40;
            lsvAircraft.Columns[2].Width = 40;

            /*
            //Remplis les données
            for (int i = 0; i < aircraftList.Count; i++)
            {
                lsvAirport.Items.Add(new ListViewItem(new string[] {  }));
            }*/
        }
    }
}
