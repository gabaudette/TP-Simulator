﻿namespace TP_Simulator
{
    class WaitingState : StateAircraft
    {
        //TODO ? Create a new Sup Class (Passenger/Cargo Plane State)
        public override void Do(Aircraft aircraft)
        {
            if (aircraft.isPassengerAicraft())
            {
                PassengerAircraft passAircraft = (PassengerAircraft)aircraft;

                for (int i = 0; i < passAircraft.airport.Clients.Count; i++)
                {
                    AirportClient airClient = (AirportClient)passAircraft.airport.Clients[i];

                    if (passAircraft.CurrentCapacity == 0)
                        passAircraft.Destination = airClient.Destination;

                    if (airClient.Destination == passAircraft.Destination)
                    {
                        if (airClient.Amount > passAircraft.MaxCapacity)
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
            else
            {
                RescueAircraft rescueAircraft = (RescueAircraft)aircraft;

                for (int i = 0; i < rescueAircraft.airport.Clients.Count; i++)
                {
                    PositionableClient posClient = (PositionableClient)rescueAircraft.airport.Clients[i];

                    if ((posClient is Fire && rescueAircraft is WaterBomber) || (posClient is Observer && rescueAircraft is ObserverPlane) || (posClient is RescueTeam && rescueAircraft is RescueHelicopter))
                    {
                        ChangeState(rescueAircraft);
                    }
                }
                
            }     
        }

        
        public override void ChangeState(Aircraft aircraft)
        {
            if (aircraft.isPassengerAicraft())
                aircraft.CurrentState = new LoadingState();
            else
                aircraft.CurrentState = new FlyingState();

        }

        public override string ToString()
        {
            return $"En attente";
        }
    }
}
