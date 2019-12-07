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
        /// <summary>
        /// Create a rescue team client
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Client CreateRescueTeam(int x, int y)
        {
            return new RescueTeam(x, y);
        }
        /// <summary>
        /// Create a fire client
        /// </summary>
        /// <param name="fireSpan"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Client CreateFire(int fireSpan, int x, int y)
        {
            return new Fire(fireSpan, x, y);
        }
        //TODO: Check assign airport (for destination) in scenario (Simulator UML Schema)
        /// <summary>
        /// Create a passenger client
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="airport"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Client CreatePassenger(int amount, Airport airport, Airport destination)
        {
            return new Passenger(amount, airport, destination);
        }
        /// <summary>
        /// Create a marchandise client
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="airport"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        //TODO: Check assign airport (for destination) in scenario (Simulator UML Schema)
        public static Client CreateMarchandise(int amount, Airport airport, Airport destination)
        {
            return new Marchandise(amount, airport, destination);
        }
        /// <summary>
        /// Create an obersver client
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Client CreateObserver(int x, int y)
        {
            return new Observer(x, y);
        }
    }
}
