namespace TP_Simulator
{
    class RescueTeam : PositionableClient
    {
        public RescueTeam(int posX, int posY) : base(posX, posY) { }

        public override string ToString()
        {
            return $"Secours en {PosX},{PosY}";
        }

    }
}
