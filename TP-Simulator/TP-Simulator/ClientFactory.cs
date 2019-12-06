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
        /*
        public static Client CreateRescueTeam(string name)
        {
            return new RescueTeam(name);
        }
        
        public static Client CreateFire(string name, int fireSpan)
        {
            return new Fire(name,fireSpan);
        }

        public static Client CreatePassenger(string name)
        {
            return new Passenger(name);
        }

        public static Client CreateMarchandise(string name, int weight)
        {
            return new Marchandise(name, weight);
        }

        public static Client CreateObserver(string name)
        {
            return new Observer(name);
        }*/
    }
}
