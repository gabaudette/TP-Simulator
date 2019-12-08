namespace TP_Simulator
{
    class WaitingState : StateAircraft
    {
        //TODO ? Create a new Sup Class (Passenger/Cargo Plane State)
        public override void Do(Aircraft aircraft)
        {
            ChangeState(aircraft);
        }

        
        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new TakeOffState();
        }

        public override string ToString()
        {
            return $"En attente";
        }
    }
}
