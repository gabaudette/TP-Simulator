namespace TP_Simulator
{
    class WaitingState : StateAircraft
    {

        /// <summary>
        /// Fill the aircraft with passenger or a positionnable client (fire,obserber,alert)
        /// </summary>
        /// <param name="aircraft"></param>
        public override void Do(Aircraft aircraft)
        {
            //Valide que le aircraft est de type passager
            if (aircraft.IsPassengerAicraft())
            {
                PassengerAircraft passAircraft = (PassengerAircraft)aircraft;

                //parcours tous les clients de l'aeroport
                for (int i = 0; i < passAircraft.airport.Clients.Count; i++)
                {
                    //verifie que le client est un client de type aeroport
                    if (passAircraft.airport.Clients[i] is AirportClient)
                    {
                        AirportClient airClient = (AirportClient)passAircraft.airport.Clients[i];

                        //Set la destination de l'avion
                        if (passAircraft.CurrentCapacity == 0)
                        {
                            passAircraft.destinationX = airClient.Destination.X;
                            passAircraft.destinationY = airClient.Destination.Y;
                        }

                        //Verifie si la destionation de l'avion est la meme que la destion du client
                        if (passAircraft.destinationX == airClient.Destination.X && passAircraft.destinationY == airClient.Destination.Y)
                        {
                            //Si l'avion est plein, changer l'etat
                            if (passAircraft.MaxCapacity - passAircraft.CurrentCapacity == 0)
                                ChangeState(passAircraft);
                            //remplir l'avion
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
            {   //Si l'avion est de type positionnable
                RescueAircraft rescueAircraft = (RescueAircraft)aircraft;

                //Parcours la liste de client
                for (int i = 0; i < rescueAircraft.airport.Clients.Count; i++)
                {
                    //Verifie que le client est de type positionnable
                    if (rescueAircraft.airport.Clients[i] is PositionableClient)
                    {
                        PositionableClient posClient = (PositionableClient)rescueAircraft.airport.Clients[i];

                        //Si le client est du meme type que l'avion qui peut le prendre en charger,faire decoller l'avion et retirer le client de la liste de client
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

        /// <summary>
        /// change the state of the plane in function on his type
        /// </summary>
        /// <param name="aircraft"></param>
        public override void ChangeState(Aircraft aircraft)
        {
            if (aircraft.IsPassengerAicraft())
                aircraft.CurrentState = new LoadingState();
            else
                aircraft.CurrentState = new FlyingState(aircraft.airport.X, aircraft.airport.Y, aircraft);

        }

        /// <summary>
        /// Return to value of the state
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"En attente";
        }
    }
}
