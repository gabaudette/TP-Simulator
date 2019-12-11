namespace TP_Simulator
{
    public class ObserverPlane : RescueAircraft
    {

        public override string ToString()
        {
            return $"{Name},Observer,{CurrentState},N/A";
        }

        public override bool isPassengerAicraft()
        {
            return false;
        }
    }
}
