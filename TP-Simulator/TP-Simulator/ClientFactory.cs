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

        public static Client CreateRescueTeam()
        {
            return new RescueTeam();
        }

        public static Client CreateFire()
        {
            return new Fire();
        }

        public static Client CreatePassenger()
        {
            return new Passenger();
        }

        public static Client CreateMarchandise()
        {
            return new Marchandise();
        }

        public static Client CreateObserver()
        {
            return new Observer();
        }
    }
}
