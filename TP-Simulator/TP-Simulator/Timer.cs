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
            if (CurrentMinute == 55)
            {
                CurrentHour++;
                CurrentMinute = 00;
            }
            else
                CurrentMinute += 5;
        }

        public override string ToString()
        {
            if (CurrentMinute == 0)
                return $"{CurrentHour} : {CurrentMinute}0";
            else if (CurrentMinute == 5)
            {
                return $"{CurrentHour} : 0{CurrentMinute}";
            }
            else
                return $"{CurrentHour} : {CurrentMinute}";
        }

        public bool HourPassed()
        {
            return CurrentHour % 1 == 0 && CurrentMinute == 0;
        }
        public bool TowHourPassed()
        {
            return CurrentHour % 2 == 0 && CurrentMinute == 0;
        }

        public bool ThirtyPassed()
        {
            return (CurrentMinute == 30);
        }
    }
}
