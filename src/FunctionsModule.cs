using Nancy;

namespace NancyTest
{
    public class FunctionsModule : NancyModule
    {
        public FunctionsModule()
        {
            Get["/functions/builtin/{name}"] = args =>
                {
                    return Response.AsJson(new {id = 3});
                };
        }
    }
}