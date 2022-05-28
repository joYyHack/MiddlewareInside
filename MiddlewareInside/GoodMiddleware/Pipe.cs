using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareInside.GoodMiddleware
{
    public abstract class Pipe
    {
        protected Action<string, string> action;
        public Pipe(Action<string, string> action)
        {
            this.action = action;
        }

        public abstract void Handle(string msg, string tabulation);
    }
}
