using System.Collections.Generic;
using System.Xml.Serialization;

namespace TP_Simulator
{
    public class Airport
    {

        private string name; //Airport's name
        private int x; //Airport's X position
        private int y; //Airport's Y position
        private int minPassenger; //Airport's minimum passenger capacity
        private int maxPassenger; //Airport's maximum passenger capacity
        private int minMarchandise; //Airport's minimum marchandise capacity
        private int maxMarchandise; //Airport's maximum marchandise capacity

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public int MinPassenger
        {
            get { return this.minPassenger; }
            set { this.minPassenger = value; }
        }

        public int MaxPassenger
        {
            get { return this.maxPassenger; }
            set { this.maxPassenger = value; }
        }

        public int MinMarchandise
        {
            get { return this.minMarchandise; }
            set { this.minMarchandise = value; }
        }
        public int MaxMarchandise
        {
            get { return this.maxMarchandise; }
            set { this.maxMarchandise = value; }
        }

        public List<Aircraft> Aircrafts { get; set; }
        Scenario scenario { get; set; }

        [XmlIgnore]
        public List<Client> Clients { get; set; }

        public Airport()
        {
            Clients = new List<Client>();
        }

        /// <summary>
        /// revive the element of the scenario
        /// </summary>
        /// <param name="scenario"></param>
        public void Reviver(Scenario scenario)
        {

            this.scenario = scenario;
            foreach (Aircraft aircraft in Aircrafts)
                aircraft.airport = this;
        }

        /// <summary>
        /// Return the value of the scenario
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name},{X},{Y},{MinPassenger},{MaxPassenger},{MinMarchandise},{MaxPassenger}";
        }

        /// <summary>
        /// Return true if the airport has a water bomber
        /// </summary>
        /// <returns></returns>
        public bool hasWaterBomber()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is WaterBomber)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// return true if the airport has a observer plane
        /// </summary>
        /// <returns></returns>
        public bool hasObserverPlane()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is ObserverPlane)
                    return true;

            }
            return false;
        }
        /// <summary>
        /// return true if the airport has a rescue helicopter
        /// </summary>
        /// <returns></returns>
        public bool hasRescueHelicopter()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is RescueHelicopter)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// return true if the airport has a cargo plane
        /// </summary>
        /// <returns></returns>
        public bool hasCargoPlane()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is CargoPlane)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// return true if the airport has a passenger plane
        /// </summary>
        /// <returns></returns>
        public bool hasPassengerPlane()
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] is PassengerPlane)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Add the plane to the flying list of the scenario
        /// </summary>
        /// <param name="aircraft"></param>
        public void takeOffPlane(Aircraft aircraft)
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] == aircraft)
                    scenario.FlyingAicrafts.Add(aircraft);
            }
        }

        /// <summary>
        /// Land the plane, remove from the airport and add to the new one, remove from the flying list and drop the passenger
        /// </summary>
        /// <param name="aircraft"></param>
        public void landPlane(Aircraft aircraft)
        {
            //Parcours les avion
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] == aircraft)
                {
                    //Parcours les aeroports
                    for (int y = 0; y < scenario.Airports.Count; y++)
                    {
                        //Si l'avion correspond a la destionation, atterir
                        if (scenario.Airports[y].X == aircraft.destinationX && scenario.Airports[y].Y == aircraft.destinationY)
                        {
                            scenario.Airports[y].Aircrafts.Add(aircraft);
                            aircraft.airport.Aircrafts.Remove(aircraft);
                            scenario.FlyingAicrafts.Remove(aircraft);
                            aircraft.airport = scenario.Airports[y];
                            PassengerAircraft passengerAircraft = (PassengerAircraft)aircraft;
                            passengerAircraft.CurrentCapacity = 0;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Reduce the fire span of the client of the plane
        /// </summary>
        /// <param name="aircraft"></param>
        public void reduceFireSpan(Aircraft aircraft)
        {
            RescueAircraft rescue = (RescueAircraft)aircraft;
            //Parcours les aeroports
            for (int i = 0; i < rescue.airport.Clients.Count; i++)
            {
                if (rescue.airport.Clients[i] is PositionableClient)
                {

                    PositionableClient posClient = (PositionableClient)rescue.airport.Clients[i];
                    //Si le client correspond au client de la list, reduire le fire span
                    if (posClient == rescue.client)
                    {
                        Fire fireClient = (Fire)rescue.client;

                        fireClient.FireSpan--;

                        rescue.destinationX = fireClient.PosX;
                        rescue.destinationY = fireClient.PosY;
                        rescue.hasArrived = false;

                    }
                }
            }
        }

        /// <summary>
        /// Check if the fire is done
        /// </summary>
        /// <param name="aircraft"></param>
        /// <returns></returns>
        public bool fireIsExtinct(Aircraft aircraft)
        {
            RescueAircraft rescue = (RescueAircraft)aircraft;
            //Parcours les clients de l'aeroport
            for (int i = 0; i < rescue.airport.Clients.Count; i++)
            {
                if (rescue.airport.Clients[i] is PositionableClient)
                {
                    PositionableClient posClient = (PositionableClient)rescue.airport.Clients[i];
                    //si le client correspond au client de l'avion, 
                    if (posClient == rescue.client)
                    {
                        Fire fireClient = (Fire)rescue.client;
                        //Si le client a son fire span a 0, return true
                        if (fireClient.FireSpan == 0)
                            return true;

                    }
                }

            }

            return false;
        }

        /// <summary>
        /// Land a rescue plane
        /// </summary>
        /// <param name="aircraft"></param>
        public void landRescue(Aircraft aircraft)
        {
            scenario.FlyingAicrafts.Remove(aircraft);
            RescueAircraft rescue = (RescueAircraft)aircraft;
            aircraft.airport.Clients.Remove(rescue.client);
            scenario.ActiveClient.Remove(rescue.client);

        }
    }
}
