namespace TP_Simulator
{
    class Marchandise : AirportClient
    {
        public int Weight { get; private set; }
        public Marchandise(int amount, Airport airport, Airport destination) : base(amount, airport, destination) { }

        public override string ToString()
        {
            return $"{Amount} tonnes de marchandises à destination de {Destination.Name}";
        }

        public override string GetTypeClient()
        {
            return "Marchandise";
        }

    }
}
