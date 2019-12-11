namespace TP_Simulator
{
    class Passenger : AirportClient
    {
        public Passenger(int amount, Airport airport, Airport destination) : base(amount, airport, destination) { }

        /// <summary>
        /// Return the value of the client
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Amount} passangers en destination de {Destination.Name}";
        }

        /// <summary>
        /// Return the type of the client
        /// </summary>
        /// <returns></returns>
        public override string  GetTypeClient()
        {
            return "Passenger";
        }
    }
}
