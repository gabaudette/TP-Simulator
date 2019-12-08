namespace TP_Simulator
{
    class Passenger : AirportClient
    {
        public Passenger(int amount, Airport airport, Airport destination) : base(amount, airport, destination) { }

        public override string ToString()
        {
            return $"{Amount} passangers en destination de {Destination}";
        }
    }
}
