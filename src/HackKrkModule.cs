using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Nancy;
using Newtonsoft.Json.Linq;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace NancyTest
{
    public class HackKrkModule : NancyModule
    {
        public const string Constant = "constant";
        public const string Invoke = "invoke";
        public const string Integer = "int";

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

                    switch ((string)json.kind)
                    {
                        case Constant:  
                            return HandleConstants(factory, json);

                        case Invoke:
                            return HandleInvokes(factory, json);

                        default:
                            return Response.AsJson("");
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

        private dynamic HandleConstants(ConstantFactory factory, dynamic json)
        {
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
                return Response.AsJson(new {error = exception.Message}, (HttpStatusCode) exception.GetHttpCode());
            }
        }

        private dynamic HandleInvokes(ConstantFactory factory, dynamic json)
        {
            var invoke = new Invoke((int)json.function, json.arguments);

            return Response.AsJson(invoke, HttpStatusCode.Created);
        }
    }
}