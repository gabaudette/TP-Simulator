using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Simulator
{
    public abstract class AirportClient : Client
    {
        public Airport Airport { get; set; }
        public int Amount { get; set; }
        public string Destination { get; set; }

        public AirportClient(int amount, Airport airport, string destination) 
        {
            Airport = airport;
            Amount = amount;
            Destination = destination;
        }

    }
}
