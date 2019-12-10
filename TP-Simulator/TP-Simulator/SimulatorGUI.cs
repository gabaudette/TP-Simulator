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
    public delegate void HourNotifier();


    public partial class SimulatorGUI : Form
    {
        Scenario scenario = Scenario.Instance;

        public SimulatorGUI()
        {
            InitializeComponent();

            picMap.Controls.Add(labTimer);
            labTimer.Location = new Point(950, 10);
            SetListView();
            //picMap.Controls.Add(picAircraft);


        }

        private void SetListView()
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
            lsvClient.Columns.Add("Clients");
            lsvClient.Columns[0].Width = lsvClient.Width - 10;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users\\Christophe\\Desktop\\Github\\TP-Builder\\TP-Builder\\WindowsFormsApp1\\bin\\Debug";
            openFileDialog.Filter = "XML Files (*.xml) | *.xml";
            //openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                ScenarioController.Deserialize(fileInfo.FullName);
            }
        }

        private void FillLsvAirport(string name, string longitude, string latitude)
        {

            lsvAirport.Items.Add(new ListViewItem(new string[] { name, longitude, latitude }));

        }

        private void FillLsvAircraft(string name, string type, string state, string destination)
        {
            lsvAircraft.Items.Add(new ListViewItem(new string[] { name, type, destination, state }));
        }

        private void FillLsvClients(string data)
        {
            lsvClient.Items.Add(new ListViewItem(new string[] { data }));
        }

        private void LsvAirport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.Clear();
            Console.WriteLine(scenario.Airports[lsvAirport.FocusedItem.Index].ToString());

            lsvAircraft.Items.Clear();
            lsvClient.Items.Clear();
            List<string> aircraftList = new List<string>();
            string aircraft;

            for (int i = 0; i < scenario.Airports[lsvAirport.FocusedItem.Index].Aircrafts.Count; i++)
            {
                aircraft = scenario.Airports[lsvAirport.FocusedItem.Index].Aircrafts[i].ToString();
                aircraftList = aircraft.Split(',').ToList();
                FillLsvAircraft(aircraftList[0], aircraftList[1], aircraftList[2], aircraftList[3]);
            }

            for (int i = 0; i < scenario.Airports[lsvAirport.FocusedItem.Index].Clients.Count; i++)
                FillLsvClients(scenario.Airports[lsvAirport.FocusedItem.Index].Clients[i].ToString());
        }

        private void PicAircraft_Click(object sender, EventArgs e)
        {

        }

        public void OnDeserialize()
        {
            string airport;
            List<string> airportList = new List<string>();

            for (int i = 0; i < scenario.Airports.Count; i++)
            {
                airport = scenario.Airports[i].ToString();
                airportList = airport.Split(',').ToList();
                FillLsvAirport(airportList[0], airportList[1], airportList[2]);
                CreateAirportIcon(Convert.ToInt32(airportList[1]), Convert.ToInt32(airportList[2]));
            }
        }

        private void CreateAirportIcon(int posX, int posY)
        {
            Bitmap airportBit = new Bitmap(Properties.Resources.airport);

            Graphics g = picMap.CreateGraphics();
            g.DrawImage(airportBit,posX,posY,30,30);

        }

        public void OnTick()
        {
            labTimer.Text = scenario.Timer.ToString();
            labTimer.Refresh();

            updateAircraftPosition();

        }

        private void updateAircraftPosition()
        {
            if (scenario.FlyingAicrafts.Count != 0)
            {
                for (int i = 0; i < scenario.FlyingAicrafts.Count; i++)
                {
                    Bitmap airportBit = new Bitmap(Properties.Resources.waterbomber);

                    if (scenario.FlyingAicrafts[i] is ObserverPlane)
                    {
                        airportBit = new Bitmap(Properties.Resources.observer);
                    }
                    else if (scenario.FlyingAicrafts[i] is RescueHelicopter)
                    {
                        airportBit = new Bitmap(Properties.Resources.helicopter);
                    }
                    else if (scenario.FlyingAicrafts[i] is PassengerPlane)
                    {
                        airportBit = new Bitmap(Properties.Resources.passengerAirplane);
                    }
                    else
                    {
                        airportBit = new Bitmap(Properties.Resources.airplane);
                    }
                }
            }
            
        }

        public void OnHour()
        {
            lsvAircraft.Refresh();
            lsvClient.Refresh();
            

            foreach (PositionableClient client in scenario.ActiveClient) 
            {
                Bitmap airportBit = new Bitmap(Properties.Resources.fire);

                if (client is Observer)
                {
                    airportBit = new Bitmap(Properties.Resources.montain);
                }
                else if (client is RescueTeam)
                {
                    airportBit = new Bitmap(Properties.Resources.signal);
                }

                Graphics g = picMap.CreateGraphics();
                g.DrawImage(airportBit, client.PosX, client.PosY, 20, 20);
            }
        }

        private void NextStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scenario.Loop();
        }

        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scenario.Stop();
        }

        private void UnpauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scenario.Start();
        }
    }
}
