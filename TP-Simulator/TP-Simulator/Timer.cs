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

        /// <summary>
        /// Add 5min to the timer
        /// </summary>
        public void AddTick()
        {
            if (CurrentMinute == 59)
            {
                CurrentHour++;
                CurrentMinute = 00;
            }
            else
                CurrentMinute += 1;
        }

        /// <summary>
        /// Return the value of the timer
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Validate if an hour have pass
        /// </summary>
        /// <returns></returns>
        public bool HourPassed()
        {
            return CurrentHour % 1 == 0 && CurrentMinute == 0;
        }
        /// <summary>
        /// Validate if 2 hour have pass
        /// </summary>
        /// <returns></returns>
        public bool TowHourPassed()
        {
            return CurrentHour % 2 == 0 && CurrentMinute == 0;
        }

        /// <summary>
        /// Validate if 30 min have pass
        /// </summary>
        /// <returns></returns>
        public bool ThirtyPassed()
        {
            return (CurrentMinute == 30);
        }
    }
}
