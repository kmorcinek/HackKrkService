using System;
using System.IO;
using System.Net;
using System.Web;
using Nancy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace NancyTest
{
    public class HackKrkModule : NancyModule
    {
        public HackKrkModule()
        {
            var factory = new ConstantFactory();

            Post["/nodes"] = x =>
                {
                    var reader = new StreamReader(Request.Body);
                    dynamic json = JObject.Parse(reader.ReadToEnd());

                    Console.WriteLine("GET /nodes {0}", json);
                    
                    try
                    {
                        Constant constant = factory.Create(json);
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