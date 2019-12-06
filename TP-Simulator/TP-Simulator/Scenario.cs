﻿using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace TP_Simulator
{
    //TODO : Delegate
    public class Scenario
    {
        private static Scenario instance = null;
        public Timer Timer { get; set; }
        public bool Pause { get; private set; }
        
        public List<Airport> Airports { get; set; }
        public List<Aircraft> FlyingAicrafts { get; set; }
        [XmlIgnore]
        public AirportNotifier AirportNotifier { get; set; }

        [XmlIgnore]
        public TickNotifier TickNotifier { get; set; }

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
                {
                    airport.Reviver(this);
                }
                Loop();
                AirportNotifier();
            }
        }

        public void Start()
        {
            while (!Pause)
            {
                Loop();
                Thread.Sleep(1000);

            }
        }

        public void Stop()
        {
            Pause = true;
        }

        public void Loop()
        {
            Timer.AddTick();
            Timer.IsTimeClient();
            TickNotifier();
        }
    }
}
