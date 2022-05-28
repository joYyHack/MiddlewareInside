using MiddlewareInside;
using MiddlewareInside.BadMiddleware;
using MiddlewareInside.GoodMiddleware;

#region BadMiddleware
BadMiddleware bad = new();

Action<string> badPipe1 = (msg) =>
    bad.Try(msg, (msg1) =>
        bad.Build(msg1, (msg2) =>
            bad.Wrap(msg2, Actions.First)));

//badPipe1("1");

Action<string> badPipe2 = (msg) =>
    bad.Try(msg, (msg1) =>
        bad.Build(msg1, (msg2) =>
            bad.Wrap(msg2, Actions.Second)));

//badPipe2("2");
#endregion

#region GoodMiddleware
var goodPipe1 = new PipeBuilder(Actions.First)
                    .AddPipe(typeof(Try))
                    .AddPipe(typeof(MiddlewareBuilder))
                    .AddPipe(typeof(Wrapper))
                    .Build();

var goodPipe2 = new PipeBuilder(Actions.Second)
                    .AddPipe(typeof(MiddlewareBuilder))
                    .AddPipe(typeof(Try))
                    .AddPipe(typeof(Wrapper))
                    .Build();

var goodPipe3 = new PipeBuilder(Actions.First);
goodPipe3.AddPipe(typeof(Try));
goodPipe3.AddPipe(typeof(MiddlewareBuilder));
goodPipe3.AddPipe(typeof(Wrapper));
var action = goodPipe3.Build();


goodPipe1("1", string.Empty);
Console.WriteLine("\n");
//Throws an error - intentionally
goodPipe2("2", string.Empty);
action("3", string.Empty);
#endregion