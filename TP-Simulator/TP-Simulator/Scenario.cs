using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TP_Simulator
{
    //TODO : Delegate
    public class Scenario
    {
        private static Scenario instance = null;
        [XmlIgnore]
        public Timer Timer { get; set; }
        [XmlIgnore]
        public bool Pause { get; private set; }
        [XmlIgnore]
        public Random Rnd { get; private set; }
        public List<Airport> Airports { get; set; }
        public List<Aircraft> FlyingAicrafts { get; set; }
        [XmlIgnore]
        public AirportNotifier AirportNotifier { get; set; }
        [XmlIgnore]
        public TickNotifier TickNotifier { get; set; }
        [XmlIgnore]
        public HourNotifier HourNotifier { get; set; }
        private ClientFactory clientFactory;
        [XmlIgnore]
        public PositionableClient LastClient { get; set; }
        [XmlIgnore]
        public List<PositionableClient> ActiveClient { get; set; }
        [XmlIgnore]
        Thread ThreadAction { get; set; }

        [XmlIgnore]
        Airport closestAirport = new Airport();

        private Scenario()
        {
            Airports = new List<Airport>();
            Timer = new Timer();
            Pause = false;
            FlyingAicrafts = new List<Aircraft>();
            ActiveClient = new List<PositionableClient>();
            ThreadAction = new Thread(new ThreadStart(Start));
        }

        /// <summary>
        /// Set the delegate
        /// </summary>
        /// <param name="view"></param>
        public void SetView(SimulatorGUI view)
        {
            AirportNotifier = new AirportNotifier(view.OnDeserialize);
            TickNotifier = new TickNotifier(view.OnTick);
            HourNotifier = new HourNotifier(view.OnHour);
        }

        /// <summary>
        /// return the instante of the scenario
        /// </summary>
        public static Scenario Instance
        {
            get
            {
                if (instance == null)
                    instance = new Scenario();
                return instance;
            }
        }

        /// <summary>
        /// deserialize a file to be used in the scenario
        /// </summary>
        /// <param name="filename"></param>
        public void Deserialize(string filename)
        {
            XmlSerializer xd = new XmlSerializer(typeof(Scenario));
            using (StreamReader rd = new StreamReader(filename))
            {
                Scenario scenario = xd.Deserialize(rd) as Scenario;

                Airports = sce­nario.Airports;
                foreach (Airport airport in Airports)
                    airport.Reviver(this);

                AirportNotifier();
                ThreadAction.Start();

            }


        }

        /// <summary>
        /// Start the loop
        /// </summary>
        public void Start()
        {
            while (!Pause)
            {
                Loop();
                Thread.Sleep(1000 / 60);
            }
        }

        /// <summary>
        /// Stop the loop
        /// </summary>
        public void Stop()
        {
            Pause = true;
        }

        /// <summary>
        /// Main loop
        /// </summary>
        public void Loop()
        {
            Timer.AddTick();
            this.clientFactory = ClientFactory.GetClientFactory();

            //If an hour passed, generate client, if 2 have passed, generate positionnable client
            if (Timer.HourPassed())
            {
                if (Timer.TowHourPassed())
                    GeneratePossitionableClient();

                GenerateClient();
            }

            //Move aircraft an update GUI
            DoAircraft();

            TickNotifier();

        }

        /// <summary>
        /// Add the client to the airport client's list
        /// </summary>
        /// <param name="paramClient"></param>
        /// <param name="type"></param>
        private void AddClientToAirport(PositionableClient paramClient, int type)
        {

            closestAirport = GetClosestAirport(paramClient, type);
            closestAirport.Clients.Add(paramClient);
        }

        /// <summary>
        /// Return the closest airport
        /// </summary>
        /// <param name="paramClient"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Airport GetClosestAirport(PositionableClient paramClient, int type)
        {
            Airport closestAirport = new Airport();
            int posX = paramClient.PosX;
            int posY = paramClient.PosY;
            double distance = 10000;

            for (int i = 0; i < Airports.Count; i++)
            {
                if ((Airports[i].hasObserverPlane() && type == 1) || (Airports[i].hasWaterBomber() && type == 2) || (Airports[i].hasRescueHelicopter() && type == 3))
                {
                    double newDistance = Math.Sqrt((Math.Pow(Airports[i].Y - posY, 2)) + (Math.Pow(Airports[i].X - posX, 2)));

                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        closestAirport = Airports[i];
                    }
                }
            }
            return closestAirport;
        }

        /// <summary>
        /// Generate non airport client (fire,observer,alert)
        /// </summary>
        public void GeneratePossitionableClient()
        {
            LastClient = new PositionableClient();

            Rnd = new Random(DateTime.Now.Millisecond);
            int nbCall;

            //Observator

            LastClient = (PositionableClient)ClientFactory.CreateObserver();
            AddClientToAirport(LastClient, 1);
            ActiveClient.Add(LastClient);
            //Fire

            LastClient = (PositionableClient)ClientFactory.CreateFire();
            AddClientToAirport(LastClient, 2);
            ActiveClient.Add(LastClient);


            //ResuceTeam
            nbCall = Rnd.Next(1, 2);
            for (int i = 0; i < nbCall; i++)
            {
                LastClient = (PositionableClient)ClientFactory.CreateRescueTeam();
                AddClientToAirport(LastClient, 3);
                ActiveClient.Add(LastClient);
            }

        }

        /// <summary>
        /// Generate airport client (passenger,cargo)
        /// </summary>
        public void GenerateClient()
        {

            int destinationID;
            Rnd = new Random(DateTime.Now.Millisecond);
            //Passenger
            for (int i = 0; i < Airports.Count; i++)
            {
                if (Airports[i].hasPassengerPlane())
                {
                    do
                        destinationID = Rnd.Next(0, Airports.Count);
                    while (i == destinationID);
                    Airports[i].Clients.Add(ClientFactory.CreatePassenger(Airports[i], Airports[destinationID]));
                }
            }

            //Marchandise
            for (int i = 0; i < Airports.Count; i++)
            {
                if (Airports[i].hasCargoPlane())
                {
                    do
                    {
                        destinationID = Rnd.Next(0, Airports.Count);
                    } while (i == destinationID);

                    Airports[i].Clients.Add(ClientFactory.CreateMarchandise(Airports[i], Airports[destinationID]));
                }
            }
        }

        /// <summary>
        /// Make evvery plane do his move
        /// </summary>
        public void DoAircraft()
        {
            for (int i = 0; i < Airports.Count; i++)
            {
                for (int y = 0; y < Airports[i].Aircrafts.Count; y++)
                    Airports[i].Aircrafts[y].CurrentState.Do(Airports[i].Aircrafts[y]);
            }
        }
    }
}
