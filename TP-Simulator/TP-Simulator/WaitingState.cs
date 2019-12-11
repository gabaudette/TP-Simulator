namespace TP_Simulator
{
    class WaitingState : StateAircraft
    {
        public override void Do(Aircraft aircraft)
        {
            if (aircraft.isPassengerAicraft())
            {
                PassengerAircraft passAircraft = (PassengerAircraft)aircraft;

                for (int i = 0; i < passAircraft.airport.Clients.Count; i++)
                {
                    if (passAircraft.airport.Clients[i] is AirportClient)
                    {
                        AirportClient airClient = (AirportClient)passAircraft.airport.Clients[i];

                        if (passAircraft.CurrentCapacity == 0)
                        {
                            passAircraft.destinationX = airClient.Destination.X;
                            passAircraft.destinationY = airClient.Destination.Y;

                        }

                        if (passAircraft.destinationX == airClient.Destination.X && passAircraft.destinationY == airClient.Destination.Y)
                        {
                            if (passAircraft.MaxCapacity - passAircraft.CurrentCapacity == 0)
                            {
                                ChangeState(passAircraft);
                            }
                            else
                            {
                                if (airClient.Amount > (passAircraft.MaxCapacity - passAircraft.CurrentCapacity))
                                {
                                    airClient.Amount -= (passAircraft.MaxCapacity - passAircraft.CurrentCapacity);
                                    passAircraft.CurrentCapacity += passAircraft.MaxCapacity - passAircraft.CurrentCapacity;
                                }
                                else
                                {
                                    passAircraft.CurrentCapacity += airClient.Amount;
                                    passAircraft.airport.Clients.Remove(passAircraft.airport.Clients[i]);
                                    i--;
                                }
                            }
                        }
                    }
                    
                }
            }
            else
            {
                RescueAircraft rescueAircraft = (RescueAircraft)aircraft;

                for (int i = 0; i < rescueAircraft.airport.Clients.Count; i++)
                {
                    if (rescueAircraft.airport.Clients[i] is PositionableClient)
                    {
                        PositionableClient posClient = (PositionableClient)rescueAircraft.airport.Clients[i];

                        if ((posClient is Fire && rescueAircraft is WaterBomber) || (posClient is Observer && rescueAircraft is ObserverPlane) || (posClient is RescueTeam && rescueAircraft is RescueHelicopter))
                        {
                            rescueAircraft.destinationX = posClient.PosX;
                            rescueAircraft.destinationY = posClient.PosY;
                            rescueAircraft.client = posClient;
                            ChangeState(rescueAircraft);
                            i = rescueAircraft.airport.Clients.Count;
                        }
                    }  
                } 
            }     
        }

        
        public override void ChangeState(Aircraft aircraft)
        {
            if (aircraft.isPassengerAicraft())
                aircraft.CurrentState = new LoadingState();
            else
                aircraft.CurrentState = new FlyingState(aircraft.airport.X, aircraft.airport.Y, aircraft);

        }

        public override string ToString()
        {
            return $"En attente";
        }
    }
}
