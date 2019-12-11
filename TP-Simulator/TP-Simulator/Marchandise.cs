namespace TP_Simulator
{
    class Marchandise : AirportClient
    {
        private int weight;

        public int Weigth
        {
            get { return weight; }
            set { weight = value; }
        }

        public Marchandise(int amount, Airport airport, Airport destination) : base(amount, airport, destination) { }


        /// <summary>
        /// Return the value of the client
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Amount} tonnes de marchandises à destination de {Destination.Name}";
        }

        /// <summary>
        /// Return the type of the client
        /// </summary>
        /// <returns></returns>
        public override string GetTypeClient()
        {
            return "Marchandise";
        }

    }
}
