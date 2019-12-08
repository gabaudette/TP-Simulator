namespace TP_Simulator
{
    class WaitingState : StateAircraft
    {
        //TODO ? Create a new Sup Class (Passenger/Cargo Plane State)
        public override void Do(Aircraft aircraft)
        {
            PassengerAircraft passAircraft = (PassengerAircraft)aircraft;

            for (int i = 0; i < passAircraft.airport.Clients.Count; i++)
            {
                AirportClient airClient = (AirportClient)passAircraft.airport.Clients[i];

                if (passAircraft.CurrentCapacity == 0)
                    passAircraft.Destination = airClient.Destination;

                if (airClient.Destination == passAircraft.Destination)
                {
                    if (airClient.Amount > passAircraft.CurrentCapacity)
                    {
                        passAircraft.CurrentCapacity += airClient.Amount;
                        airClient.Amount = airClient.Amount - passAircraft.CurrentCapacity;
                    }
                    else
                    {
                        passAircraft.CurrentCapacity += airClient.Amount;
                        passAircraft.airport.Clients.Remove(passAircraft.airport.Clients[i]);
                    }
                }
            }

            if (passAircraft.MaxCapacity == 0)
            {
                ChangeState(passAircraft);
            }
        }

        
        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new LoadingState();
        }

        public override string ToString()
        {
            return $"En attente";
        }
    }
}
