using System.Web;

namespace NancyTest
{
    class ConstantFactory
    {
        private int _id = 0;

        public Constant Create(dynamic request)
        {
            if (request.kind == "int")
            {
                int value;
                if (int.TryParse(request.value, out value) == false)
                {
                    throw new HttpException(422, "Could not parse integer");
                }
                return new IntConstant(++_id, request.value);
            }
            return null;
        }
    }
}