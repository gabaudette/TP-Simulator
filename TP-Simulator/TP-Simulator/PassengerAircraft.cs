using System;
using System.Xml.Serialization;

namespace TP_Simulator
{
    public class PassengerAircraft : Aircraft
    {
        public int LoadingTime { get; set; }
        public int UnloadingTime { get; set; }
        public int MaxCapacity { get; set; }

        [XmlIgnore]
        public int CurrentCapacity { get; set; }


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
        public override bool isPassengerAicraft()
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
