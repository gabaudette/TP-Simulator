namespace TP_Simulator
{
    public class ObserverPlane : RescueAircraft
    {
        /// <summary>
        /// return the value of the plane
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name},Observer,{CurrentState},N/A";
        }

        /// <summary>
        /// return true if the plane can carry passenger
        /// </summary>
        /// <returns></returns>
        public override bool IsPassengerAircraft()
        {
            return false;
        }

        /// <summary>
        /// return the type of the plane
        /// </summary>
        /// <returns></returns>
        public override string GetTypeAircraft()
        {
            return "ObserverPlane";
        }
    }
}
