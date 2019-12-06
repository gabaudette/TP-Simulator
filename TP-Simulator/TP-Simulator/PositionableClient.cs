
namespace TP_Simulator
{
    class PositionableClient : Client
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public PositionableClient(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }


    }
}
