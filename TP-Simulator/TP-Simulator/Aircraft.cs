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
        protected Airport currentAirport;
        protected string name;
        protected int speed;
        protected int maintenance;

        public Airport airport
        {
            get { return this.currentAirport; }
            set { this.currentAirport = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public int Maintenance
        {
            get { return this.maintenance; }
            set { this.maintenance = value; }
        }

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
        public abstract bool IsPassengerAircraft();
    }
}
