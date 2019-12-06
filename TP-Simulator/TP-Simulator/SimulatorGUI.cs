using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace TP_Simulator
{
    public delegate void AirportNotifier();
    public delegate void TickNotifier();

    public partial class SimulatorGUI : Form
    {
        Scenario scenario = Scenario.Instance;

        public SimulatorGUI()
        {
            InitializeComponent();

            picMap.Controls.Add(labTimer);
            labTimer.Location = new Point(950, 10);
            setListView();
            //picMap.Controls.Add(picAircraft);


        }

        private void setListView()
        {
            lsvAirport.View = View.Details;

            //Ajoute les colonnes
            lsvAirport.Columns.Add("Nom");
            lsvAirport.Columns.Add("Longitude");
            lsvAirport.Columns.Add("Lattitude");


            //Remplis les colonnes
            lsvAirport.Columns[0].Width = 115;
            lsvAirport.Columns[1].Width = 80;
            lsvAirport.Columns[2].Width = 80;

            lsvAircraft.View = View.Details;

            //Ajoute les colonnes
            lsvAircraft.Columns.Add("Nom");
            lsvAircraft.Columns.Add("Type");
            lsvAircraft.Columns.Add("Destination");
            lsvAircraft.Columns.Add("États");


            //Remplis les colonnes
            lsvAircraft.Columns[0].Width = 110;
            lsvAircraft.Columns[1].Width = 60;
            lsvAircraft.Columns[2].Width = 120;
            lsvAircraft.Columns[3].Width = 70;

            lsvClient.Clear();

            lsvClient.View = View.Details;

            //Ajoute les colonnes
            lsvClient.Columns.Add("Nombre");
            lsvClient.Columns.Add("Type");
            lsvClient.Columns.Add("Destination");


            //Remplis les colonnes
            lsvClient.Columns[0].Width = 150;
            lsvClient.Columns[1].Width = 70;
            lsvClient.Columns[2].Width = 90;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users\\Christophe\\Desktop\\Github\\TP-Builder\\TP-Builder\\WindowsFormsApp1\\bin\\Debug";
            openFileDialog.Filter = "XML Files (*.xml) | *.xml";
            //openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                ScenarioController.Deserialize(fileInfo.FullName);
            }
        }

        private void fillLsvAirport(string name, string longitude, string latitude){ 

            lsvAirport.Items.Add(new ListViewItem(new string[] { name,longitude,latitude }));
            
        }

        private void fillLsvAircraft(string name, string type, string state,string destination)
        {

           lsvAircraft.Items.Add(new ListViewItem(new string[] { name,type,destination, state }));

        }

        private void fillLsvClients()
        {
            lsvAirport.Items.Add(new ListViewItem(new string[] {  }));

        }

        private void LsvAirport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.Clear();
            Console.WriteLine(scenario.Airports[lsvAirport.FocusedItem.Index].ToString());

            lsvAircraft.Items.Clear();
            List<string> aircraftList = new List<string>();
            string aircraft;

            for (int i = 0; i < scenario.Airports[lsvAirport.FocusedItem.Index].Aircrafts.Count; i++)
            {
                aircraft = scenario.Airports[lsvAirport.FocusedItem.Index].Aircrafts[i].ToString();
                aircraftList = aircraft.Split(',').ToList();
                fillLsvAircraft(aircraftList[0], aircraftList[1], aircraftList[2], aircraftList[3]);
            }

            
        }

        private void PicAircraft_Click(object sender, EventArgs e)
        {

        }

        public void onDeserialize()
        {
            string airport;
            List<string> airportList = new List<string>();

            for (int i = 0; i < scenario.Airports.Count; i++)
            {
                airport = scenario.Airports[i].ToString();
                airportList = airport.Split(',').ToList();
                fillLsvAirport(airportList[0], airportList[1], airportList[2]);
                createAirportIcon(Convert.ToInt32(airportList[1]), Convert.ToInt32(airportList[2]));
            }
        }

        private void createAirportIcon(int posX, int posY) {

            PictureBox pb = new PictureBox
            {
                Size = new Size(20, 20),
                Location = new Point(posX, posY),
                Image = Properties.Resources.airport,
                BackColor = Color.Black,
            };

            picMap.Controls.Add(pb);
            pb.BringToFront();
        }


        public void onTick()
        {
            labTimer.Text = scenario.timer.ToString();
        }

        private void nextStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scenario.loop();
        }
    }
}
