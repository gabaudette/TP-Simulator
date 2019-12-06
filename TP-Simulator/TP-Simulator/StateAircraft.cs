namespace TP_Simulator
{
    public abstract class StateAircraft
    {
        public Aircraft aircraft { get; protected set; }
        public StateAircraft()
        {
            //aircraft = new Aircraft();
        }
        protected abstract void Do();

    }
}
