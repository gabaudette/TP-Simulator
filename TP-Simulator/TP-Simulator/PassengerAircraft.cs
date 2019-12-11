using System;
using System.Xml.Serialization;

namespace TP_Simulator
{
    public class PassengerAircraft : Aircraft
    {
        protected int loadingTime;
        protected int unloadingTime;
        protected int maxCapacity;
        protected int currentCapacity;

        public int LoadingTime
        {
            get { return this.loadingTime; }
            set { this.loadingTime = value; }
        }
 
        public int UnloadingTime
        {
            get { return this.unloadingTime; }
            set { this.unloadingTime = value; }
        }



        public int MaxCapacity
        {
            get { return this.maxCapacity; }
            set { this.maxCapacity = value; }
        }

        [XmlIgnore]
        public int CurrentCapacity
        {
            get { return this.currentCapacity; }
            set { this.currentCapacity = value; }
        }

        /// <summary>
        /// Move the airplane
        /// </summary>
        /// <param name="aircraft"></param>
        public override void MoveAircraft(Aircraft aircraft)
        {
            //calcul la nouvelle position en x et y
            int destX = aircraft.destinationX;
            int destY = aircraft.destinationY;

            PassengerAircraft passAircraft = (PassengerAircraft)aircraft;
            FlyingState position = (FlyingState)passAircraft.CurrentState;
            double distance = Math.Sqrt((Math.Pow(destY - position.PosY, 2)) + (Math.Pow(destX - position.PosX, 2)));

            double tickRequired = distance / (passAircraft.Speed * 15);

            // Si le nombre de tick est plus grand que 1, deplacer l'avion
            if (tickRequired > 1)
            {
                double XbyTick = (destX - position.PosX) / tickRequired;
                double YbyTick = (destY - position.PosY) / tickRequired;


                position.PosX += Convert.ToInt32(XbyTick);
                position.PosY += Convert.ToInt32(YbyTick);
            }
            else // sinon, l'avion est a destination
            {
                aircraft.CurrentState.ChangeState(aircraft);
            }
        }

        /// <summary>
        /// Return true if the plane can carry passenger
        /// </summary>
        /// <returns></returns>
        public override bool IsPassengerAircraft()
        {
            return true;
        }

        /// <summary>
        /// return the type of the aircraft
        /// </summary>
        /// <returns></returns>
        public override string GetTypeAircraft()
        {
            return "PassengerAircraft";
        }
    }
}
