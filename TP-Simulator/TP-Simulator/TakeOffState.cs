using System;

namespace TP_Simulator
{
    class TakeOffState : StateAircraft
    {
        public override string ToString()
        {
            return $"Décollage";
        }

        protected override void Do()
        {
            throw new NotImplementedException();
        }
    }
}
