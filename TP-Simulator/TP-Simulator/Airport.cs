using System.Collections.Generic;

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

        public Airport() { }
        
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
