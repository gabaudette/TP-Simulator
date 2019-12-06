
namespace TP_Simulator
{
    class nonAirportClient : Client
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public nonAirportClient(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }


    }
}
