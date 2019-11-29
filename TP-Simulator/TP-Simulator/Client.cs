namespace TP_Simulator
{
    public abstract class Client
    {
        public string Name { get; protected set; }
        public Client(string name)
        {
            Name = name;
        }
    }
}
