using System;

namespace TP_Simulator
{
    class FlyingState : StateAircraft
    {
        public override void Do(Aircraft aircraft)
        {
            ChangeState(aircraft);
        }

        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new LandingState();
        }

        public override string ToString()
        {
            return $"En Vol";
        }
    }
}
