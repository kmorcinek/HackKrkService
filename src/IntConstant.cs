namespace NancyTest
{
    class IntConstant : Constant
    {
        public int value { get; set; }

        public IntConstant(int value)
            : base(HackKrkModule.Int)
        {
            this.value = value;
        }
    }
}