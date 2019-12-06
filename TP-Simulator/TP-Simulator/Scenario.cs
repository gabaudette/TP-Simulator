using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Threading;

namespace TP_Simulator
{
    //TODO : Delegate
    public class Scenario
    {
        private static Scenario instance = null;
        public Timer timer { get; set; }
        private bool pause { get; set; }
        
        public List<Airport> Airports { get; set; }
        public List<Aircraft> FlyingAicrafts { get; set; }
        [XmlIgnore]
        public AirportNotifier airportNotifier { get; set; }

        [XmlIgnore]
        public TickNotifier tickNotifier { get; set; }



        private Scenario()
        {
            Airports = new List<Airport>();
            this.timer = new Timer();
            pause = false;
        }



        public void SetView(SimulatorGUI view)
        {
            airportNotifier = new AirportNotifier(view.onDeserialize);
            tickNotifier = new TickNotifier(view.onTick);
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

                loop();
                airportNotifier();
                
            }
        }

        public void Start()
        {
            pause = false;
        }
        public void Stop()
        {
            pause = true;
        }

        public void loop()
        {
            timer.addTick();
            tickNotifier();
 
        }
    }
}
