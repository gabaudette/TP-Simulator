namespace TP_Simulator
{
    public class WaterBomber : RescueAircraft
    {
        public int WaterCapacity { get; set; }
        public int DroppingTime { get; set; }


        public override string ToString()
        {
            return $"{Name},WaterBomber,{CurrentState},N/A";
        }

        public override bool isPassengerAicraft()
        {
            return false;
        }

    }
}
