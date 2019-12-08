namespace TP_Simulator
{
    //TODO ? Create a new Sup Class (Passenger/Cargo Plane State)
    class LoadingState : StateAircraft
    {
        public override void Do(Aircraft aircraft)
        {

        }

        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new TakeOffState();
        }

        public override string ToString()
        {
            return $"Chargement";
        }
    }
}
