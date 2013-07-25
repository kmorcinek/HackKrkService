using System;
using System.Net;
using System.Web;
using Nancy;
using HttpStatusCode = Nancy.HttpStatusCode;

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

                    try
                    {
                        Constant constant = factory.Create(x);
                        return Response.AsJson(constant, HttpStatusCode.Created);
                    }
                    catch (HttpException exception)
                    {
                        return Response.AsJson(new {error = exception.Message}, (HttpStatusCode) exception.ErrorCode);
                    }
                };
        }
    }
}