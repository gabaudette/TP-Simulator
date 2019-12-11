namespace TP_Simulator
{
    class RescueTeam : PositionableClient
    {
        public RescueTeam(int posX, int posY) : base(posX, posY) { }

        /// <summary>
        /// Return the value of the rescue client
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Secours en {PosX},{PosY}";
        }

        /// <summary>
        /// Return the type of the client
        /// </summary>
        /// <returns></returns>
        public override string GetTypeClient()
        {
            return "RescueTeam";
        }
    }
}
