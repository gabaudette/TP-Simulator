namespace TP_Simulator
{
    class MaintenanceSate : StateAircraft
    {
        /// <summary>
        /// Reduce the time of mainteance, if its 0, change the state of the plane
        /// </summary>
        /// <param name="aircraft"></param>
        public override void Do(Aircraft aircraft)
        {
            if (aircraft.Maintenance == 0)
                ChangeState(aircraft);
            else
                aircraft.Maintenance--;

        }

        /// <summary>
        /// Change the state to waiting state
        /// </summary>
        /// <param name="aircraft"></param>
        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new WaitingState();

        }

        /// <summary>
        /// Return the value of the state
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Maintenance";
        }
    }
}
