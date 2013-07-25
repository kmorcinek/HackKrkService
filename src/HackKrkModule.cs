using System;
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
        public const string Int = "int";
        public const string Bool = "bool";

        public static int Incrementer = 0;

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

                    return ConstantFactory.GetConstant(id);
                };

            Get["/nodes/{id}/evaluate"] = x =>
            {
                var id = (int)x.id;
                var constant = ConstantFactory.GetConstant(id);

                var intConstant = constant as IntConstant;
                if (intConstant != null)
                {
                    return Response.AsJson(new { result = intConstant.value });
                }

                var boolConstant = constant as BoolConstant;
                if (boolConstant != null)
                {
                    return Response.AsJson(new { result = boolConstant.value });
                }
                
                throw new NotImplementedException();
            };
        }

        private dynamic HandleConstants(ConstantFactory factory, dynamic json)
        {
            try
            {
                Constant constant = factory.Create(json);

                return Response.AsJson(constant, HttpStatusCode.Created);
            }
            catch (HttpException exception)
            {
                return Response.AsJson(new {error = exception.Message}, (HttpStatusCode) exception.GetHttpCode());
            }
        }

        private dynamic HandleInvokes(ConstantFactory factory, dynamic json)
        {
            var arguments = json.arguments;
            var array = new int[]
                {
                    arguments[0],
                    arguments[1]
                };
            var invoke = new Invoke((int)json.function, array);

            return Response.AsJson(invoke, HttpStatusCode.Created);
        }
    }
}