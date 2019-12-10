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

        public override void moveAicraft(Aircraft aircraft)
        {

            int destX = aircraft.destinationX;
            int destY = aircraft.destinationY;

            PassengerAircraft passAircraft = (PassengerAircraft)aircraft;
            FlyingState position = (FlyingState)passAircraft.CurrentState;
            double distance = Math.Sqrt((Math.Pow(destY - position.PosY, 2)) + (Math.Pow(destX - position.PosX, 2)));

            double tickRequired = distance / (passAircraft.Speed * 30);

            if (tickRequired > 1)
            {
                double XbyTick = (destX - position.PosX) / tickRequired;
                double YbyTick = (destY - position.PosY) / tickRequired;


                position.PosX += Convert.ToInt32(XbyTick);
                position.PosY += Convert.ToInt32(YbyTick);
            }
            else
            {
                aircraft.CurrentState.ChangeState(aircraft);
            }

            

        }

        public override bool isPassengerAicraft()
        {
            return true;
        }

    }
}
