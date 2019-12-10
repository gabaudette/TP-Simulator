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
        public List <PositionableClient> ActiveClient { get; set; }

        [XmlIgnore]
        Airport closestAirport = new Airport();
        [XmlIgnore]
        Thread threadAction;

        private Scenario()
        {
            Airports = new List<Airport>();
            Timer = new Timer();
            Pause = false;
            FlyingAicrafts = new List<Aircraft>();
            ActiveClient = new List<PositionableClient>();
        }

        public void SetView(SimulatorGUI view)
        {
            AirportNotifier = new AirportNotifier(view.OnDeserialize);
            TickNotifier = new TickNotifier(view.OnTick);
            HourNotifier = new HourNotifier(view.OnHour);
        }

        public static Scenario Instance
        {
            get
            {
                if (instance == null)
                    instance = new Scenario();
                return instance;
            }
        }

        public void Deserialize(string filename)
        {
            XmlSerializer xd = new XmlSerializer(typeof(Scenario));
            using (StreamReader rd = new StreamReader(filename))
            {
                Scenario scenario = xd.Deserialize(rd) as Scenario;

                Airports = sce­nario.Airports;
                foreach(Airport airport in Airports)
                    airport.Reviver(this);

                AirportNotifier();

                //if (threadAction == null)
                    //threadAction = new Thread(new ThreadStart(Start));

            }


        }

        public void Start()
        {
            while (!Pause)
            {
                Loop();
                Thread.Sleep(500);
            }
        }

        public void Stop()
        {
            Pause = true;
        }

        public void Loop()
        {
            Timer.AddTick();
            this.clientFactory = ClientFactory.GetClientFactory();
            if (Timer.HourPassed()) {
                generateClient();
            }
            
            doAircraft();
            TickNotifier();
        }

        private void addClientToAirport(PositionableClient paramClient, int type)
        {
            
            closestAirport = getClosestAirport(paramClient, type);
            closestAirport.Clients.Add(paramClient);
        }

        public Airport getClosestAirport(PositionableClient paramClient, int type)
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

        public void generateClient()
        {
            Console.WriteLine("Client generer");
            LastClient = new PositionableClient();

            Rnd = new Random(DateTime.Now.Millisecond);
            int nbCall;
            int destinationID;

            //Observator
            /*
            LastClient = (PositionableClient)ClientFactory.CreateObserver();
            addClientToAirport(LastClient, 1);
            ActiveClient.Add(LastClient);

            //Fire
            nbCall = Rnd.Next(1, 3);
            for (int i = 0; i < nbCall; i++)
            {
                LastClient = (PositionableClient)ClientFactory.CreateFire();
                addClientToAirport(LastClient, 2);
                ActiveClient.Add(LastClient);
            }*/

            //ResuceTeam
            nbCall = Rnd.Next(1, 2);
            for (int i = 0; i < nbCall; i++)
            {
                LastClient = (PositionableClient)ClientFactory.CreateRescueTeam();
                addClientToAirport(LastClient, 3);
                ActiveClient.Add(LastClient);
            }

            //Passenger
            for (int i = 0; i < Airports.Count; i++)
            {
                if (Airports[i].hasPassengerPlane())
                {
                    do
                    {
                        destinationID = Rnd.Next(0, Airports.Count);
                    } while (i == destinationID); 
                    Airports[i].Clients.Add(ClientFactory.CreatePassenger(Airports[i], Airports[destinationID]));
                }

            }

            //Marchandise
            for (int i = 0; i < Airports.Count; i++)
            {
                for (int y = 0; y < 3; y++)
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
        }

        public void doAircraft()
        {
            for (int i = 0; i < Airports.Count; i++)
            {
                for (int y = 0; y < Airports[i].Aircrafts.Count; y++)
                {
                    Airports[i].Aircrafts[y].CurrentState.Do(Airports[i].Aircrafts[y]);
                }
            }
        }
    }
}
