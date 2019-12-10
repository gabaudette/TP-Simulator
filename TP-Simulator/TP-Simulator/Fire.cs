namespace TP_Simulator
{
    class Fire : PositionableClient
    {
        public int FireSpan { get; private set; }
        public Fire(int fireSpan, int posX, int posY) : base(posX, posY)
        {
            FireSpan = fireSpan;
        }

        public override string ToString()
        {
            return $"Incendie d'envergure {FireSpan} détecté en {PosX} {PosY}";
        }

    }
}
