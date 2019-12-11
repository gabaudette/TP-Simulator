namespace TP_Simulator
{
    public class WaterBomber : RescueAircraft
    {

        public int WaterCapacity { get; set; }
        public int DroppingTime { get; set; }

        /// <summary>
        /// Return the value of the waterbomber
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name},WaterBomber,{CurrentState},N/A";
        }

        /// <summary>
        /// return true if the plane is a passenger aircraft
        /// </summary>
        /// <returns></returns>
        public override bool isPassengerAicraft()
        {
            return false;
        }

        /// <summary>
        /// return the type of the aircraft
        /// </summary>
        /// <returns></returns>
        public override string GetTypeAircraft()
        {
            return "WaterBomber";
        }

    }
}
