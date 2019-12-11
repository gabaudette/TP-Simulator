﻿using System.Xml.Serialization;

namespace TP_Simulator
{
    public class RescueHelicopter : RescueAircraft
    {

        /// <summary>
        /// Return the value of the plabe
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name},RescueHelicopter,{CurrentState},N/A";
        }

        /// <summary>
        /// return true if the aircraft can carry passenger
        /// </summary>
        /// <returns></returns>
        public override bool isPassengerAicraft()
        {
            return false;
        }

        /// <summary>
        /// Return the type of the aircraft
        /// </summary>
        /// <returns></returns>
        public override string GetTypeAircraft()
        {
            return "RescueHelicopter";
        }
    }
}
