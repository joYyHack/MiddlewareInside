using MiddlewareInsideAspNetCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("start 1");
    await next(context);
    await context.Response.WriteAsync("\nend 1");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("\n\tstart 2");
    await next(context);
    await context.Response.WriteAsync("\n\tend 2");
});

app.UseCustomMiddleware();

//app.MapGet("/", () => "Hello World!");

app.Run(async context =>
{
    await context.Response.WriteAsync("\n\t\t\tartjom");
});

app.Run();
