using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting.Self;

namespace HackKrkNancy
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            bootstrapper.Initialise();
            var host = new NancyHost(bootstrapper, new Uri("http://127.0.0.1:8080"));

            host.Start();

            Console.ReadLine();
        }
    }

    public class Foo : NancyModule
    {
        public Foo() : base("/")
        {
            Get["@/nodes"] = x =>
                {
                    return Response.AsJson(new Constant { Id = 1 });
                };
        }
    }

    public class Constant
    {
        public int Id { get; set; }
    }
}
