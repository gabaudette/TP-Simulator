namespace TP_Simulator
{
    class Marchandise : AirportClient
    {
        public int Weight { get; private set; }
        public Marchandise(int amount,Airport airport, string destination) : base(amount, airport,destination){ }

        public override string ToString()
        {
            return $"{Amount} tonnes à destination de {Destination}";
        }
    }
}
