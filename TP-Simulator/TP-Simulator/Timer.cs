namespace TP_Simulator
{
    public class Timer
    {
        public int CurrentMinute{ get; set; }
        public int CurrentHour { get; set; }

        public Timer()
        {
            CurrentHour = 0;
            CurrentMinute = 0;
        }

        public void AddTick()
        {
            if (CurrentMinute == 45)
            {
                CurrentHour++;
                CurrentMinute = 00;
            }
            else
                CurrentMinute += 15;
        }

        public override string ToString()
        {
            if (CurrentMinute == 0)
                return $"{CurrentHour} : {CurrentMinute}0";
            else
                return $"{CurrentHour} : {CurrentMinute}";
        }
    }
}
