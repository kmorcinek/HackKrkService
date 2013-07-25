using System;

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
}
