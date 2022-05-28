using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareInside.GoodMiddleware
{
    public class Try : Pipe
    {
        public Try(Action<string, string> action) : base(action)
        {
        }

        public override void Handle(string msg, string tabulation)
        {
            Console.WriteLine($"{tabulation}Try Catch block has been started");
            try
            {
                action(msg, tabulation is null ? "\t" : tabulation + "\t");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{tabulation}Exception was thrown: {ex.Message}");
                action(msg, tabulation is null ? "\t" : tabulation + "\t");
                Console.WriteLine($"{tabulation}Exception has been finished");
            }
            Console.WriteLine($"{tabulation}Try Catch block has been stopped");
        }
    }
}
