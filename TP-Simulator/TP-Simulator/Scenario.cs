using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
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
        Airport closestAirport = new Airport();

        private Scenario()
        {
            Airports = new List<Airport>();
            Timer = new Timer();
            Pause = false;
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

                Loop();
                AirportNotifier();
            }
        }

        public void Start()
        {
            while (!Pause)
            {
                Loop();
                //Thread.Sleep(1000);
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
                LastClient = new PositionableClient();
                Rnd = new Random(DateTime.Now.Millisecond);
                int nbCall;
                int destinationID;
                //Observator
                LastClient = (PositionableClient)ClientFactory.CreateObserver();
                addClientToAirport(LastClient);

                //Fire
                nbCall = Rnd.Next(1, 3);
                for (int i = 0; i < nbCall; i++)
                {
                    LastClient = (PositionableClient)ClientFactory.CreateFire();
                    addClientToAirport(LastClient);
                }

                //ResuceTeam
                nbCall = Rnd.Next(1, 2);
                for (int i = 0; i < nbCall; i++)
                {
                    LastClient = (PositionableClient)ClientFactory.CreateRescueTeam();
                    addClientToAirport(LastClient);
                }

                //Passenger
                for (int i = 0; i < Airports.Count; i++)
                {
                    destinationID = Rnd.Next(0, Airports.Count);
                    ClientFactory.CreatePassenger(Airports[i], Airports[destinationID]);
                }

                //Marchandise
                for (int i = 0; i < Airports.Count; i++)
                {
                    destinationID = Rnd.Next(0, Airports.Count);
                    ClientFactory.CreateMarchandise(Airports[i], Airports[destinationID]);
                }

                HourNotifier();
            }

            TickNotifier();
        }

        private void addClientToAirport(PositionableClient paramClient)
        {
            
            closestAirport = getClosestAirport(paramClient.PosX, paramClient.PosY);
            closestAirport.Clients.Add(paramClient);
        }

        public Airport getClosestAirport(int posX,int posY)
        {
            Airport closestAirport = new Airport();

            double distance = 10000;

            for (int i = 0; i < Airports.Count; i++)
            {
               double newDistance = Math.Sqrt((Math.Pow(Airports[i].Y - posY,2)) + (Math.Pow(Airports[i].X - posX, 2)));

                if (newDistance < distance)
                {
                    distance = newDistance;
                    closestAirport = Airports[i];
                }
                
            }

            return closestAirport;
        }

    }
}
