namespace TP_Simulator
{
    public class ObserverPlane : Aircraft
    {

        public override string ToString()
        {
            return $"{Name},Observer,{CurrentState},N/A";
        }
    }
}
