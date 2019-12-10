using System.Xml.Serialization;

namespace TP_Simulator
{
    public class RescueHelicopter : RescueAircraft
    {

        public override string ToString()
        {
            return $"{Name},RescueHelicopter,{CurrentState},N/A";
        }

        public override bool isPassengerAicraft()
        {
            return false;
        }

    }
}
