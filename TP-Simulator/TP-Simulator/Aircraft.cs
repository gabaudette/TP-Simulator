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
       public Aircraft() { }
    }
}
