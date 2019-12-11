namespace TP_Simulator
{
    //TODO ? Create a new Sup Class (Passenger/Cargo Plane State)
    class LoadingState : StateAircraft
    {
        /// <summary>
        /// Load the plane, when it's done, change the state
        /// </summary>
        /// <param name="aircraft"></param>
        public override void Do(Aircraft aircraft)
        {
            PassengerAircraft passAircraft = (PassengerAircraft)aircraft;

            if (passAircraft.LoadingTime == 0)
                ChangeState(passAircraft);
            else
                passAircraft.LoadingTime--;

        }

        /// <summary>
        /// Change the state of the plane to flying
        /// </summary>
        /// <param name="aircraft"></param>
        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new FlyingState(aircraft.airport.X,aircraft.airport.Y, aircraft);

            
        }

        /// <summary>
        /// return the state of the plane
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Chargement";
        }
    }
}
