namespace TP_Simulator
{
    public class Observer : PositionableClient
    {
        public Observer(int posX, int posY) : base(posX,posY) { }

        public override string ToString()
        {
            return $"Obersation en {PosX},{PosY}";
        }

        public override string GetTypeClient()
        {
            return "Observer";
        }
    }
}
