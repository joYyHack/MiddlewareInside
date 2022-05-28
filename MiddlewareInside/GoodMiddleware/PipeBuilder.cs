using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareInside.GoodMiddleware
{
    public class PipeBuilder
    {
        readonly Action<string, string> mainAction;
        readonly List<Type> pipeTypes;

        public PipeBuilder(Action<string, string> mainAction)
        {
            this.mainAction = mainAction;
            pipeTypes = new();
        }

        public PipeBuilder AddPipe(Type pipeType)
        {
            if (!typeof(Pipe).IsAssignableFrom(pipeType))
            {
                throw new Exception("Incorrect type of pipe!");
            }

            pipeTypes.Add(pipeType);
            return this;
        }

        Action<string, string> CreatePipe(int pipeIndex = 0)
        {
            if (pipeIndex < pipeTypes.Count - 1)
            {
                var nextPipeAction = CreatePipe(pipeIndex + 1);
                var pipe = Activator.CreateInstance(pipeTypes[pipeIndex], nextPipeAction) as Pipe;
                return pipe.Handle;
            }

            var lastPipe = Activator.CreateInstance(pipeTypes[pipeIndex], mainAction) as Pipe;
            return lastPipe.Handle;
        }

        public Action<string, string> Build()
        {
            return CreatePipe();
        }
    }
}
