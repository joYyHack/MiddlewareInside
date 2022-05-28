using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareInside
{
    public class Actions
    {
        public static void First(string msg)
        {
            Console.WriteLine($"\t\t\tExecuting 1 function ... MSG: {msg}");
        }

        public static void First(string msg, string tabulation)
        {
            Console.WriteLine($"{tabulation}Executing 1 function ... MSG: {msg}");
        }

        public static void Second(string msg)
        {
            Console.WriteLine($"\t\t\tExecuting 2 function ... MSG: {msg}");
        }

        public static void Second(string msg, string tabulation)
        {
            Console.WriteLine($"{tabulation}Executing 2 function ... MSG: {msg}");
        }
    }
}
