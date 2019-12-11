namespace TP_Simulator
{
    public class PassengerPlane : PassengerAircraft
    {

        public override string ToString()
        {
            return $"{Name},Passager,{CurrentState.ToString()}, ?";
        }

        public override bool isPassengerAicraft()
        {
            return true;
        }

        public override string GetTypeAircraft()
        {
            return "PassengerPlane";
        }
    }


}
