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
    }
}
