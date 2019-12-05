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

        public Aircraft() { }
    }
}
