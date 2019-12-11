namespace TP_Simulator
{
    class Fire : PositionableClient
    {
        private int fireSpan;

        public int FireSpan
        {
            get { return fireSpan; }
            set { fireSpan = value; }
        }

        public Fire(int fireSpan, int posX, int posY) : base(posX, posY)
        {
            FireSpan = fireSpan;
        }

        /// <summary>
        /// Return the value of the client
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Incendie d'envergure {FireSpan} détecté en {PosX} {PosY}";
        }

        /// <summary>
        /// Return the type of the client
        /// </summary>
        /// <returns></returns>
        public override string GetTypeClient()
        {
            return "Fire";
        }
    }
}
