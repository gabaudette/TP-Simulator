namespace TP_Simulator
{
    public abstract class StateAircraft
    {
        public StateAircraft()
        {
        }
        /// <summary>
        /// Generic function that make the airplane do his move
        /// </summary>
        /// <param name="aircraft"></param>
        public abstract void Do(Aircraft aircraft);
        /// <summary>
        /// Generic function that change the state of the plane
        /// </summary>
        /// <param name="aircraft"></param>
        public abstract void ChangeState(Aircraft aircraft);


    }
}
