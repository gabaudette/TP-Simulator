﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TP_Simulator
{
    //TODO : Delegate
    public class Scenario
    {
        private static Scenario instance = null;
        private Timer timer;
        
        public List<Airport> Airports { get; set; }
        public List<Aircraft> FlyingAircrafts { get; set; }
        

        private Scenario()
        {
            Airports = new List<Airport>();
            this.timer = new Timer();
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
            }
        }

        public void Start()
        {
            
        }
        public void Stop()
        {
            
        }
    }
}
