namespace TP_Simulator
{
    public class Timer
    {
        public int currentMinute{ get; set; }
        public int currentHour { get; set; }
        public Timer()
        {
            currentHour = 0;
            currentMinute = 0;
        }

        public void addTick ()
        {
            if (currentMinute == 45)
            {
                currentHour++;
                currentMinute = 00;
            }
            else
                currentMinute += 15;
        }


        public override string ToString()
        {
            if (currentMinute == 0)
                return $"{currentHour} : {currentMinute}0";
            else
                return $"{currentHour} : {currentMinute}";
            
        }
    }
}
