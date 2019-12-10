 using System.Collections.Generic;
using System.Xml.Serialization;

namespace TP_Simulator
{
    public class Airport
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MinPassenger { get; set; }
        public int MaxPassenger { get; set; }
        public int MinMarchandise { get; set; }
        public int MaxMarchandise { get; set; }
        public List<Aircraft> Aircrafts { get; set; }
        Scenario scenario { get; set; }

        [XmlIgnore]
        public List<Client> Clients { get; set; }

        public Airport() {
            Clients = new List<Client>();
        }
        
        public void Reviver(Scenario scenario)
        {
            
            this.scenario = scenario;
            foreach(Aircraft aircraft in Aircrafts)
                aircraft.airport = this;
        }

        public override string ToString()
        {
            return $"{Name},{X},{Y},{MinPassenger},{MaxPassenger},{MinMarchandise},{MaxPassenger}";
        }

        public bool hasWaterBomber()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is WaterBomber)
                    return true;
            }
            return false;
        }

        public bool hasObserverPlane()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is ObserverPlane)
                    return true;

            }
            return false;
        }

        public bool hasRescueHelicopter()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is RescueHelicopter)
                    return true;
            }
            return false;
        }

        public bool hasCargoPlane()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is CargoPlane)
                    return true;
            }
            return false;
        }

        public bool hasPassengerPlane()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is PassengerPlane)
                    return true;
            }
            return false;
        }

        public void takeOffPlane(Aircraft aircraft)
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] == aircraft)
                {
                    scenario.FlyingAicrafts.Add(aircraft);
                }
            }
        }


    }
}
