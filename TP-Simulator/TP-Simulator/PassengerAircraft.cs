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
        public Airport Destination{ get; set; }
        [XmlIgnore]
        public int CurrentCapacity { get; set; }

        public override void moveAicraft(Aircraft aircraft)
        {

            PassengerAircraft passAircraft = (PassengerAircraft)aircraft;
            Airport destAirport = passAircraft.Destination;
            FlyingState position = (FlyingState)passAircraft.CurrentState;
            double distance = Math.Sqrt((Math.Pow(destAirport.Y - position.PosY, 2)) + (Math.Pow(destAirport.X - position.PosX, 2)));

            double tickRequired = distance / (passAircraft.Speed * 15);
            double XbyTick = (destAirport.X - position.PosX) / tickRequired;
            double YbyTick = (destAirport.Y - position.PosY) / tickRequired;


            position.PosX = position.PosX + Convert.ToInt32(XbyTick);
            position.PosY = position.PosY + Convert.ToInt32(YbyTick);

        }

        public override bool isPassengerAicraft()
        {
            return true;
        }

    }
}
