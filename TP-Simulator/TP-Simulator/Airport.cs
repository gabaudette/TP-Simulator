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

        public Airport()
        {
            Clients = new List<Client>();
        }

        public void Reviver(Scenario scenario)
        {

            this.scenario = scenario;
            foreach (Aircraft aircraft in Aircrafts)
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

        public void landPlane(Aircraft aircraft)
        {
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                if (Aircrafts[i] == aircraft)
                {

                    for (int y = 0; y < scenario.Airports.Count; y++)
                    {
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

        public void reduceFireSpan(Aircraft aircraft)
        {
            RescueAircraft rescue = (RescueAircraft)aircraft;

            for (int i = 0; i < rescue.airport.Clients.Count; i++)
            {
                if (rescue.airport.Clients[i].GetTypeClient() == "PositionableClient")
                {

                    PositionableClient posClient = (PositionableClient)rescue.airport.Clients[i];

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

        public bool fireIsExtinct(Aircraft aircraft)
        {
            RescueAircraft rescue = (RescueAircraft)aircraft;

            for (int i = 0; i < rescue.airport.Clients.Count; i++)
            {
                if (rescue.airport.Clients[i].GetTypeClient() == "PositionableClient")
                {
                    PositionableClient posClient = (PositionableClient)rescue.airport.Clients[i];

                    if (posClient == rescue.client)
                    {
                        Fire fireClient = (Fire)rescue.client;

                        if (fireClient.FireSpan == 0)
                            return true;

                    }
                }

            }

            return false;
        }

        public void landRescue(Aircraft aircraft)
        {
            scenario.FlyingAicrafts.Remove(aircraft);
            RescueAircraft rescue = (RescueAircraft)aircraft;
            aircraft.airport.Clients.Remove(rescue.client);
            scenario.ActiveClient.Remove(rescue.client);

        }


    }
}
