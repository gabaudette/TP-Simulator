using System;

namespace TP_Simulator
{
    class FlyingState : StateAircraft
    {
        public int PosX { get; set; }
        public int PosY { get; set; }


        public FlyingState(int posX,int posY, Aircraft aircraft)
        {
            PosX = posX;
            PosY = posY;

            aircraft.airport.takeOffPlane(aircraft);
        }

        public override void Do(Aircraft aircraft)
        {
            PassengerAircraft passengerAircraft = (PassengerAircraft)aircraft;
            /*
            if (passengerAircraft.Destination.X == aircraft.CurrentState.)
            {

            }*/
            aircraft.moveAicraft(aircraft);


            
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
