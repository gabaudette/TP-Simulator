using System;

namespace TP_Simulator
{
    class LandingState : StateAircraft
    {
        protected override void Do()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Atterissage";
        }
    }
}
