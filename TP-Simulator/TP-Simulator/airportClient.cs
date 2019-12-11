namespace TP_Simulator
{
    public class AirportClient : Client
    {
        public Airport Airport { get; set; }
        public int Amount { get; set; }
        public Airport Destination { get; set; }

        /// <summary>
        /// Return the type of the client
        /// </summary>
        /// <returns></returns>
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
