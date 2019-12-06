using System;

namespace TP_Simulator
{
    class FlyingState : StateAircraft
    {
        protected override void Do()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"En Vol";
        }
    }
}
