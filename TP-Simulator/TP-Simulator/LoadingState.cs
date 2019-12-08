namespace TP_Simulator
{
    //TODO ? Create a new Sup Class (Passenger/Cargo Plane State)
    class LoadingState : StateAircraft
    {
        public override void Do(Aircraft aircraft)
        {
            PassengerAircraft passAircraft = (PassengerAircraft)aircraft;

            if (passAircraft.LoadingTime == 0)
                ChangeState(passAircraft);
            else
                passAircraft.LoadingTime--;

        }

        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new FlyingState();
        }

        public override string ToString()
        {
            return $"Chargement";
        }
    }
}
