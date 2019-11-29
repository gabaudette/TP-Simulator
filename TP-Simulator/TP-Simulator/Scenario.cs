namespace TP_Simulator
{
    public sealed class Scenario
    {
        private static Scenario instance = null;

        public static Scenario Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Scenario();
                }
                return instance;
            }
        }
    }
}
