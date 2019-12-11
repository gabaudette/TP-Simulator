namespace TP_Simulator
{
    class FlyingState : StateAircraft
    {
        protected int posX;
        protected int posY;


        public int PosX
        {
            get { return this.posX; }
            set { this.posX = value; }
        }

        public int PosY
        {
            get { return this.posY; }
            set { this.posY = value; }
        }

        public FlyingState(int posX, int posY, Aircraft aircraft)
        {
            PosX = posX;
            PosY = posY;

            aircraft.airport.takeOffPlane(aircraft);
        }


        /// <summary>
        /// Move the airplane
        /// </summary>
        /// <param name="aircraft"></param>
        public override void Do(Aircraft aircraft)
        {

            aircraft.MoveAircraft(aircraft);

        }

        /// <summary>
        /// Change the state of the plane in function of the type of the plane
        /// </summary>
        /// <param name="aircraft"></param>
        public override void ChangeState(Aircraft aircraft)
        {
            if (aircraft is PassengerAircraft)
                aircraft.CurrentState = new UnloadingState(aircraft);
            else if (aircraft is WaterBomber)
            {
                aircraft.airport.landRescue(aircraft);
                aircraft.CurrentState = new MaintenanceSate(); 
            }
            else
            {
                aircraft.airport.landRescue(aircraft);
                aircraft.CurrentState = new MaintenanceSate();
            }


        }

        /// <summary>
        /// Return the state of the plane
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"En Vol";
        }

    }
}
