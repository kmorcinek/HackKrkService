namespace NancyTest
{
    class IntConstant : Constant
    {
        public IntConstant(int value) : base(HackKrkModule.Integer)
        {
            this.value = value;
        }
        public int value { get; set; }
    }
}