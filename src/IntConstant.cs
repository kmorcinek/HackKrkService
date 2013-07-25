namespace NancyTest
{
    class IntConstant : Constant
    {
        public IntConstant(int id, int value) : base(id, "int")
        {
            this.value = value;
        }
        public int value { get; set; }
    }
}