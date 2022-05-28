using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareInside.GoodMiddleware
{
    public class MiddlewareBuilder : Pipe
    {
        bool ExceptionIsAlreadyThrown = false;

        public MiddlewareBuilder(Action<string, string> action) : base(action) { }

        public override void Handle(string msg, string tabulation)
        {
            if (!ExceptionIsAlreadyThrown)
            {
                ExceptionIsAlreadyThrown = true;
                throw new Exception("Intentional exception was thrown");
            }

            Console.WriteLine($"{tabulation}Build good middleware has been started");
            action(msg, tabulation is null ? "\t" : tabulation + "\t");
            Console.WriteLine($"{tabulation}Build block has been stopped");
        }
    }
}
