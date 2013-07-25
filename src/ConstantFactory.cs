using System;
using System.Collections.Generic;
using System.Web;

namespace NancyTest
{
    class ConstantFactory
    {
        public static Dictionary<int, Constant> Storage = new Dictionary<int, Constant>();

        public Constant Create(dynamic request)
        {
            var type = (string)request.type;
            Console.WriteLine("type: {0}", type);
            if (type == HackKrkModule.Integer)
            {
                int value;
                var val = (string)request.value;
                if (Int32.TryParse(val, out value) == false)
                {
                    throw new HttpException(422, "Could not parse integer");
                }

                var intConstant = new IntConstant(value);

                Storage.Add(intConstant.id, intConstant);

                return intConstant;
            }
            return null;
        }

        public Constant CreateIntOrBool(int id)
        {
            var intConstant = new IntConstant(id);

            Storage.Add(intConstant.id, intConstant);

            return intConstant;
        }

        public static Constant GetConstant(int id)
        {
            if (Storage.ContainsKey(id))
            {
                return Storage[id];
            }
            return null;
        }
    }
}