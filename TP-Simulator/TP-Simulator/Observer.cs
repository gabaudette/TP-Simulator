
namespace TP_Simulator
{
    public class Observer : PositionableClient
    {
        public Observer(int posX, int posY) : base(posX,posY) { }


        /// <summary>
        /// Return the value of the client
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Obersation en {PosX},{PosY}";
        }

        /// <summary>
        /// Return the type of the client
        /// </summary>
        /// <returns></returns>
        public override string GetTypeClient()
        {
            return "Observer";
        }
    }
}
