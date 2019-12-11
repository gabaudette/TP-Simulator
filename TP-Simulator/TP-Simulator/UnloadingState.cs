namespace TP_Simulator
{
    class UnloadingState : StateAircraft
    {

        public UnloadingState(Aircraft aircraft)
        {
            aircraft.airport.landPlane(aircraft);

        }

        /// <summary>
        /// if unloading time is not a 0, reduce unloading time, else change state
        /// </summary>
        /// <param name="aircraft"></param>
        public override void Do(Aircraft aircraft)
        {
            PassengerAircraft passAircraft = (PassengerAircraft)aircraft;

            if (passAircraft.UnloadingTime == 0)
                ChangeState(passAircraft);
            else
                passAircraft.UnloadingTime--;
        }


        /// <summary>
        /// Change the state of the aircraft to maintenant
        /// </summary>
        /// <param name="aircraft"></param>
        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new MaintenanceSate();
        }

        /// <summary>
        /// Return the status of the plane
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Débarquement";
        }
    }
}
