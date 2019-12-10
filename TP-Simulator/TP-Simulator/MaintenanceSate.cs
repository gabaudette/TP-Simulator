namespace TP_Simulator
{
    class MaintenanceSate : StateAircraft
    {
        public override void Do(Aircraft aircraft)
        {
            if (aircraft.Maintenance == 0)
                ChangeState(aircraft);
            else
                aircraft.Maintenance--;

        }
        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new WaitingState();

        }

        public override string ToString()
        {
            return "Maintenance";
        }
    }
}
