namespace NancyTest
{
    class IntConstant : Constant
    {
        public IntConstant(int id, int value) : base("int", id)
        {
            this.value = value;
        }
        public int value { get; set; }
    }
}