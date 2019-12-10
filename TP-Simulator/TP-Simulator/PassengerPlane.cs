namespace TP_Simulator
{
    public class PassengerPlane : PassengerAircraft
    {

        public override string ToString()
        {
            return $"{Name},Passager,{CurrentState.ToString()},wtf je sais pas";
        }

        public override bool isPassengerAicraft()
        {
            return true;
        }
    }


}
