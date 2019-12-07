using System;

namespace TP_Simulator
{
    class LandingState : StateAircraft
    {
        public override void Do(Aircraft aircraft)
        {
            ChangeState(aircraft);
        }

        public override void ChangeState(Aircraft aircraft)
        {
            aircraft.CurrentState = new UnloadingState();
        }

        public override string ToString()
        {
            return $"Atterissage";
        }
    }
}
