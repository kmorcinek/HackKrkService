using Nancy;

namespace NancyTest
{
    public class FunctionsModule : NancyModule
    {
        public FunctionsModule()
        {
            Get["/functions/builtin/{name}"] = args =>
                {
                    var functions = new Functions();
                    var functionName = (string) args.name;

                    if (functions.NameToId.ContainsKey(functionName))
                    {
                        var functionId = functions.NameToId[functionName];

                        return Response.AsJson(new { id = functionId }); 
                    }

                    return Response.AsJson("");
                };
        }
    }
}