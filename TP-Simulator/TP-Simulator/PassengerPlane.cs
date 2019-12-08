namespace TP_Simulator
{
    public class PassengerPlane : PassengerAircraft
    {

        public override string ToString()
        {
            return $"{Name},Passager,{CurrentState.ToString()},Cuba";
        }
    }


}
