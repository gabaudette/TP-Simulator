namespace TP_Simulator
{
    public class AirportClient : Client
    {
        public Airport Airport { get; set; }
        public int Amount { get; set; }
        public Airport Destination { get; set; }

        public override string GetTypeClient()
        {
            return "AirportClient";
        }

        public AirportClient(int amount, Airport airport, Airport destination) 
        {
            Airport = airport;
            Amount = amount;
            Destination = destination;
        }

    }
}
