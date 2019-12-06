namespace TP_Simulator
{
    class Passenger : AirportClient
    {
        public Passenger(int amount,Airport airport, string destination) : base(amount,airport,destination) { }

        public override string ToString()
        {
            return $"{Amount} passangers ont embarqués en destination de {Destination}";
        }
    }
}
