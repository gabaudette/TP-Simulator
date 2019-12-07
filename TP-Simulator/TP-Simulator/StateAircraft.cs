namespace TP_Simulator
{
    public abstract class StateAircraft
    {
        public StateAircraft()
        {
        }
        public abstract void Do(Aircraft aircraft);
        public abstract void ChangeState(Aircraft aircraft);
    }
}
