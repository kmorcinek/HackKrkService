using System;
using Nancy;

namespace NancyTest
{
    public class HackKrkModule : NancyModule
    {
        public HackKrkModule()
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
}