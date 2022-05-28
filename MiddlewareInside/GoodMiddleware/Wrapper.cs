using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareInside.GoodMiddleware
{
    public class Wrapper : Pipe
    {
        public Wrapper(Action<string, string> action) : base(action)
        {
        }

        public override void Handle(string msg, string tabulation)
        {
            Console.WriteLine($"{tabulation}Wrapper has been started");
            action(msg, tabulation is null ? "\t" : tabulation + "\t");
            Console.WriteLine($"{tabulation}Wrapper has been stopped");
        }
    }
}
