namespace TP_Simulator
{
    public class CargoPlane : PassengerAircraft
    {

        public override string ToString()
        {
            try
            {

                return $"{Name},Cargo,{CurrentState.ToString()},wtf je sais pas";
            }
            catch (System.Exception)
            {

                return $"{Name},Cargo,{CurrentState.ToString()}, Undefined "; ;
            }  
        }

        public override bool isPassengerAicraft()
        {
            return true;
        }

    }
}
