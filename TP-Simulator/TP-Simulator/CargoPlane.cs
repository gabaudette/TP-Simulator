namespace TP_Simulator
{
    public class CargoPlane : PassengerAircraft
    {
        /// <summary>
        /// Return the value of the state
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name},Cargo,{CurrentState.ToString()}"; 
        }

        /// <summary>
        /// Return true if the plane can carry passenger
        /// </summary>
        /// <returns></returns>
        public override bool IsPassengerAircraft()
        {
            return true;
        }

        /// <summary>
        /// Return the type of the aicraft
        /// </summary>
        /// <returns></returns>
        public override string GetTypeAircraft()
        {
            return "CargoPlane";
        }

    }
}
