using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareInside.BadMiddleware
{
    public class BadMiddleware
    {
        public void Wrap(string msg, Action<string> function)
        {
            Console.WriteLine("\t\tWrapper has been started");
            function(msg);
            Console.WriteLine("\t\tWrapper has been stopped");
        }

        public void Build(string msg, Action<string> function)
        {
                Console.WriteLine("\tBuild bad middleware has been started");
                function(msg);
                Console.WriteLine("\tBuild block has been stopped");
        }

        public void Try(string msg, Action<string> function)
        {
            try
            {
                Console.WriteLine("Try block has been started");
                function(msg);
                Console.WriteLine("Try block has been stopped\n");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
