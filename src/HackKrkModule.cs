using System;
using System.Collections.Generic;
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
        public static int Incrementer = 0;
        static Dictionary<int, object> _storage = new Dictionary<int, object>();

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
                        if (constant != null)
                        {
                            _storage.Add(constant.id, constant);
                        }
                        return Response.AsJson(constant, HttpStatusCode.Created);
                    }
                    catch (HttpException exception)
                    {
                        return Response.AsJson(new { error = exception.Message }, (HttpStatusCode)exception.GetHttpCode());
                    }
                };

            Get["/nodes/{id}"] = x =>
                {
                    var id = (int)x.id;
                    if (_storage.ContainsKey(id))
                    {
                        return _storage[id];
                    }
                    return null;
                };
        }
    }
}