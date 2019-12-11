
namespace TP_Simulator
{
    public class PositionableClient : Client
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public PositionableClient() { }

        public PositionableClient(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }


        /// <summary>
        /// Return the type of the client
        /// </summary>
        /// <returns></returns>
        public override string GetTypeClient()
        {
            return "PositionableClient";
        }

    }
}
