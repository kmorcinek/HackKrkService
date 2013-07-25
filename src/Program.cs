using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;

namespace NancyTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var host = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost:8080"));
            host.Start();

            Console.ReadKey();
        }
    }

    public class Foo : NancyModule
    {
        public Foo()
        {
            Get["/nodes"] = x =>
                {
                    Console.WriteLine("GET /nodes {0}", Request.Body);
                    
                    var factory = new ConstantFactory();
                    Constant constant = factory.Create(x);
                    return Response.AsJson(constant, HttpStatusCode.Created);
                };
        }
    }

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

    internal class Constant
    {
        public Constant(int id, string type)
        {
            this.id = id;
            this.type = type;
        }

        public int id { get; set; }
        public string kind { get; set; }
        public string type { get; set; }
    }

    class IntConstant : Constant
    {
        public IntConstant(int id, dynamic request) : base(id, "int")
        {
            value = request.value;
        }
        public int value { get; set; }
    }
}
