﻿using System.Xml.Serialization;

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
        public StateAircraft CurrentState { get; protected set; }

        public Aircraft() {

            CurrentState = new LoadingState();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
