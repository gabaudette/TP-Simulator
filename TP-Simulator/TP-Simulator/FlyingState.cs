using System;

namespace TP_Simulator
{
    class FlyingState : StateAircraft
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public FlyingState(int posX, int posY, Aircraft aircraft)
        {
            PosX = posX;
            PosY = posY;

            aircraft.airport.takeOffPlane(aircraft);
        }

        public override void Do(Aircraft aircraft)
        {

            aircraft.MoveAircraft(aircraft);

        }

        public override void ChangeState(Aircraft aircraft)
        {
            if (aircraft is PassengerAircraft)
                aircraft.CurrentState = new UnloadingState(aircraft);
            else if (aircraft is WaterBomber)
            {
                aircraft.airport.landRescue(aircraft);
                aircraft.CurrentState = new MaintenanceSate(); 
            }
            else
            {
                aircraft.airport.landRescue(aircraft);
                aircraft.CurrentState = new MaintenanceSate();
            }


        }

        public override string ToString()
        {
            return $"En Vol";
        }

    }
}
