namespace TP_Simulator
{
    class UnloadingState : StateAircraft
    {
        //TODO ? Create a new Sup Class (Passenger/Cargo Plane State)
        public override void Do(Aircraft aircraft)
        {
            ChangeState(aircraft);
        }

        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new MaintenanceSate();
        }

        public override string ToString()
        {
            return $"Débarquement";
        }
    }
}
