namespace TP_Simulator
{
    public sealed class ClientFactory
    {
        private static ClientFactory clientFactory;

        private ClientFactory() { }

        public static ClientFactory GetClientFactory()
        {
            if (clientFactory == null)
                clientFactory = new ClientFactory();
            return clientFactory;
        }
        
        public static Client CreateRescueTeam(int x, int y)
        {
            return new RescueTeam(x, y);
        }
        
        public static Client CreateFire(int fireSpan, int x, int y)
        {
            return new Fire(fireSpan, x, y);
        }

        //TODO: Check assign airport (for destination) in scenario (Simulator UML Schema)
        public static Client CreatePassenger(int amount, Airport airport, Airport destination)
        {
            return new Passenger(amount, airport, destination);
        }

        //TODO: Check assign airport (for destination) in scenario (Simulator UML Schema)
        public static Client CreateMarchandise(int amount, Airport airport, Airport destination)
        {
            return new Marchandise( amount,airport,destination);
        }

        public static Client CreateObserver(int x, int y)
        {
            return new Observer(x, y);
        }
    }
}
