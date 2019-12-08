namespace TP_Simulator
{
    public class CargoPlane : PassengerAircraft
    {

        public override string ToString()
        {
            return $"{Name},Cargo,{CurrentState.ToString()},Cuba";
        }

    }
}
