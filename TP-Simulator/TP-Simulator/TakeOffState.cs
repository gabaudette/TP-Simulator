using System;

namespace TP_Simulator
{
    class TakeOffState : StateAircraft
    {

        public override void Do(Aircraft aircraft)
        {
            ChangeState(aircraft);
        }

        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new FlyingState();
        }

        public override string ToString()
        {
            return $"Décollage";
        }
    }
}
