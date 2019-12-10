 using System.Xml.Serialization;

namespace TP_Simulator
{
    [XmlInclude(typeof(CargoPlane))]
    [XmlInclude(typeof(ObserverPlane))]
    [XmlInclude(typeof(PassengerPlane))]
    [XmlInclude(typeof(WaterBomber))]
    [XmlInclude(typeof(RescueHelicopter))]
    public abstract class Aircraft
    {
        public Airport airport { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Maintenance { get; set; }
        enum TrackColor { Red, Yellow, Blue, Green, Grey };
        [XmlIgnore]
        public StateAircraft CurrentState { get; set; }

        [XmlIgnore]
        public int destinationX { get; set; }
        [XmlIgnore]
        public int destinationY { get; set; }

        public Aircraft() {
            
            CurrentState = new MaintenanceSate();
        }

        public void Request()
        {
            CurrentState.Do(this);
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public abstract void moveAicraft(Aircraft aircraft);

        public abstract bool isPassengerAicraft();
    }
}
