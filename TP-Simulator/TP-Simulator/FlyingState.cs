using System;

namespace TP_Simulator
{
    class FlyingState : StateAircraft
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public override void Do(Aircraft aircraft)
        {
            aircraft.moveAicraft(aircraft);

            PassengerAircraft passengerAircraft = (PassengerAircraft)aircraft;


            if (false) // airplane x,y = airport x,y
            {
                ChangeState(aircraft);
            }
            
        }

        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new UnloadingState();
        }

        public override string ToString()
        {
            return $"En Vol";
        }

    }
}
