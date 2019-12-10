namespace TP_Simulator
{
    class UnloadingState : StateAircraft
    {
        //TODO ? Create a new Sup Class (Passenger/Cargo Plane State)
        public override void Do(Aircraft aircraft)
        {
            PassengerAircraft passAircraft = (PassengerAircraft)aircraft;

            if (passAircraft.UnloadingTime == 0)
                ChangeState(passAircraft);
            else
                passAircraft.UnloadingTime--;
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
