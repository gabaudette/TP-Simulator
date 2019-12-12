namespace TP_Simulator
{
    public class PassengerPlane : PassengerAircraft
    {

        /// <summary>
        /// Return the value of the planen
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name},Passager,{CurrentState.ToString()}, ?";
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
        /// Return the type of the airplane
        /// </summary>
        /// <returns></returns>
        public override string GetTypeAircraft()
        {
            return "PassengerPlane";
        }
    }


}
