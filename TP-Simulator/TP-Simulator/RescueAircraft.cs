using System;
using System.Xml.Serialization;

namespace TP_Simulator
{
    public class RescueAircraft : Aircraft
    {

        [XmlIgnore]
        public bool hasArrived { get; set; }

        [XmlIgnore]
        public PositionableClient client { get; set; }

        public override void moveAicraft(Aircraft aircraft)
        {
            int destX = aircraft.destinationX;
            int destY = aircraft.destinationY;

            RescueAircraft rescueAircraft = (RescueAircraft)aircraft;
            FlyingState position = (FlyingState)rescueAircraft.CurrentState;
            double distance = Math.Sqrt((Math.Pow(destY - position.PosY, 2)) + (Math.Pow(destX - position.PosX, 2)));

            double tickRequired = distance / (rescueAircraft.Speed * 50);

            if (tickRequired > 1)
            {
                double XbyTick = (destX - position.PosX) / tickRequired;
                double YbyTick = (destY - position.PosY) / tickRequired;

                position.PosX += Convert.ToInt32(XbyTick);
                position.PosY += Convert.ToInt32(YbyTick);
            }
            else if (tickRequired < 1 && rescueAircraft.hasArrived == false)
            {
                hasArrived = true;

                position.PosX = destX;
                position.PosY = destY;

                aircraft.destinationX = aircraft.airport.X;
                aircraft.destinationY = aircraft.airport.Y;

            }
            else
            {
                if (aircraft is WaterBomber)
                {
                    if (!airport.fireIsExtinct(aircraft)) // to change
                    {
                        aircraft.CurrentState.ChangeState(aircraft);
                        rescueAircraft.hasArrived = false;
                    }
                    else
                    {
                        aircraft.airport.X = aircraft.destinationX;
                        aircraft.airport.Y = aircraft.destinationY;

                    }
                }
                else
                {
                    aircraft.CurrentState.ChangeState(aircraft);
                    rescueAircraft.hasArrived = false;
                }
    
                

                
            }
        }

        public override bool isPassengerAicraft()
        {
            return false;
        }

    }
}
