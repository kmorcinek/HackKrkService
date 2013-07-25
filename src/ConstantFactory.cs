namespace NancyTest
{
    class ConstantFactory
    {
        private int _id = 0;

        public Constant Create(dynamic request)
        {
            if (request.kind == "int")
            {
                return new IntConstant(++_id, request.value);
            }
            return null;
        }
    }
}