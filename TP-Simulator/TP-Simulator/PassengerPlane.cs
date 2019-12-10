namespace TP_Simulator
{
    public class PassengerPlane : PassengerAircraft
    {

        public override string ToString()
        {
            return $"{Name},Passager,{CurrentState.ToString()},{Destination.Name}";
        }

        public override bool isPassengerAicraft()
        {
            return true;
        }
    }


}
