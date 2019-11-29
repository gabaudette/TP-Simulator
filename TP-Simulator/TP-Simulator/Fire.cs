namespace TP_Simulator
{
    class Fire : Client
    {
        public int FireSpan { get; private set; }
        public Fire(string name, int fireSpan) : base(name)
        {
            FireSpan = fireSpan;
        }
    }
}
