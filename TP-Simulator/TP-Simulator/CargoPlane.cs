namespace TP_Simulator
{
    public class CargoPlane : PassengerAircraft
    {
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Name},Cargo,{CurrentState.ToString()},Cuba";
        }
    }
}
