using Middleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection
builder.Services.AddTransient<MyCustomMiddleware>();  

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("First Middleware");
//});
//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Second Middleware");
//});
//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Third Middleware");
//});


//first middleware
app.Use(async (context, next) =>
{
    //authentication
    await context.Response.WriteAsync("First Middleware\n");
    await next(context);
});

//second middleware
app.Use(async (context, next) =>
{
    //authorization
    await context.Response.WriteAsync("Second Middleware\n");
    await next(context);
});


//user custom middleware from the pipeline
//app.UseMiddleware<MyCustomMiddleware>();
app.UseMyCustomMiddleware();


//three middleware - (Terminating middleware)
app.Run(async (context) =>
{
    //redirection
    await context.Response.WriteAsync("Three Middleware\n");
});

app.Run();
