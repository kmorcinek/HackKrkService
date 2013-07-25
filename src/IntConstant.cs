namespace NancyTest
{
    class IntConstant : Constant
    {
        public IntConstant(int id, dynamic request) : base(id, "int")
        {
            value = request.value;
        }
        public int value { get; set; }
    }
}