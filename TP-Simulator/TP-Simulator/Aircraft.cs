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
        /// <summary>
        /// Do the move of the state
        /// </summary>
        public void Request()
        {
            CurrentState.Do(this);
        }

        /// <summary>
        /// Return the value of the plane
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }

        /// <summary>
        /// Return the type of the plane
        /// </summary>
        /// <returns></returns>
        public abstract string GetTypeAircraft();

        /// <summary>
        /// Generic function to move differant type of aircraft
        /// </summary>
        /// <param name="aircraft"></param>
        public abstract void MoveAircraft(Aircraft aircraft);

        /// <summary>
        /// Return true if the plane can carry passenger
        /// </summary>
        /// <returns></returns>
        public abstract bool isPassengerAicraft();
    }
}
