
namespace TP_Simulator
{
    public class PositionableClient : Client
    {
        protected int posX;
        protected int posY;
       

        public int PosX
        {
            get { return this.posX; }
            set { this.posX = value; }
        }

        public int PosY
        {
            get { return this.posY; }
            set { this.posY = value; }
        }


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
