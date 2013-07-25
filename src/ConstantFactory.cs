using System;
using System.Web;

namespace NancyTest
{
    class ConstantFactory
    {
        private static int _id = 0;

        public Constant Create(dynamic request)
        {
            var type = (string)request.type;
            Console.WriteLine("type: {0}", type);
            if (type == HackKrkModule.Integer)
            {
                int value;
                var val = (string) request.value;
                if (int.TryParse(val, out value) == false)
                {
                    throw new HttpException(422, "Could not parse integer");
                }
                return new IntConstant(value);
            }
            return null;
        }
    }
}