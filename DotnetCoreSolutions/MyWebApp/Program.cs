//web application object

//create web app obj
var builder = WebApplication.CreateBuilder(args);

//web app obj is ready here
var app = builder.Build();

//get me the response with the following text
//app.MapGet("/", () => "Hello from MyWeb Application!");

//app.Run(async (HttpContext context) =>
//{
//    //if (1 == 2)
//    //{
//    //    context.Response.StatusCode = 200;
//    //}
//    //else
//    //{
//    //    context.Response.StatusCode = 400;
//    //}
//    //await context.Response.WriteAsync("Hello Mr.Shrey. Welcome to ASP.NET CORE 1");
//    //await context.Response.WriteAsync("Hello Mr.Shrey. Welcome to ASP.NET CORE 2");
//});

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    {
        string auth = context.Request.Headers["AuthorizationKey"];
        await context.Response.WriteAsync($"<p>{auth}</p>");
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("<p>UnAuthorised Request!</p>");
    }
});


//to start web server(kestrel/IIS etc.)
app.Run();
