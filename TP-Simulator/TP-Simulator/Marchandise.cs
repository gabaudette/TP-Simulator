namespace TP_Simulator
{
    class Marchandise : Client
    {
        public int Weight { get; private set; }
        public Marchandise(string name, int weight) : base(name)
        {
            Weight = weight;
        }
    }
}
