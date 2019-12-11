using System;
using System.Xml.Serialization;

namespace TP_Simulator
{
    public class RescueAircraft : Aircraft
    {

        [XmlIgnore]
        public bool HasArrived { get; set; }

        [XmlIgnore]
        public PositionableClient client { get; set; }

        /// <summary>
        /// Move the aircraft
        /// </summary>
        /// <param name="aircraft"></param>
        public override void MoveAircraft(Aircraft aircraft)
        {

            //Calcul le deplacement en x et y de 1 tick de l'avion
            int destX = aircraft.destinationX;
            int destY = aircraft.destinationY;

            RescueAircraft rescueAircraft = (RescueAircraft)aircraft;
            FlyingState position = (FlyingState)rescueAircraft.CurrentState;
            double distance = Math.Sqrt((Math.Pow(destY - position.PosY, 2)) + (Math.Pow(destX - position.PosX, 2)));

            double tickRequired = distance / (rescueAircraft.Speed * 15);

            //Si le tick est plus grand que 1, deplacer l'avion
            if (tickRequired > 1)
            {
                double XbyTick = (destX - position.PosX) / tickRequired;
                double YbyTick = (destY - position.PosY) / tickRequired;

                position.PosX += Convert.ToInt32(XbyTick);
                position.PosY += Convert.ToInt32(YbyTick);
            }//Sinon, l'avion est arrivé
            else if (tickRequired < 1 && rescueAircraft.HasArrived == false)
            {
                HasArrived = true;

                position.PosX = destX;
                position.PosY = destY;

                aircraft.destinationX = aircraft.airport.X;
                aircraft.destinationY = aircraft.airport.Y;
            }
            else
            { 
                if (aircraft is WaterBomber) // Si l'avion est un water bomber
                {
                    if (airport.fireIsExtinct(aircraft)) // verifie su le feu est éteint
                    {
                        aircraft.CurrentState.ChangeState(aircraft);
                        rescueAircraft.HasArrived = false;
                    }
                    else // si le feu n'est pas éteint, reduire son envergure
                    {
                        aircraft.airport.reduceFireSpan(aircraft);
                    }
                }
                else
                { // sinon, changer son etat
                    aircraft.CurrentState.ChangeState(aircraft);
                    rescueAircraft.HasArrived = false;
                }             
            }
        }

        /// <summary>
        /// Return true if the plane is a passenger plane
        /// </summary>
        /// <returns></returns>
        public override bool IsPassengerAicraft()
        {
            return false;
        }

        /// <summary>
        /// Return the type of the plane
        /// </summary>
        /// <returns></returns>
        public override string GetTypeAircraft()
        {
            return "RescueAircraft";
        }
    }
}
