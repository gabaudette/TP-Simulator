
namespace TP_Simulator
{
    class PositionableAirportClient : Client
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public PositionableAirportClient(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }


    }
}
