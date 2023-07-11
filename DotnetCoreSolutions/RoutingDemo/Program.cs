var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//enable routing
app.UseRouting();

//create your endpoints(Resources)
//app.UseEndpoints(endpoints =>
//{
//    //add your endpoints here
//    //endpoints.MapGet("", async (context) =>
//    //{
//    //    await context.Response.WriteAsync("In Home page");
//    //});
//    endpoints.MapGet("map1", async (context) =>
//    {
//        await context.Response.WriteAsync("In Map1");
//    });
//    endpoints.MapGet("map2", async (context) =>
//    {
//        await context.Response.WriteAsync("In Map2");
//    });
//    endpoints.MapGet("map3", async (context) =>
//    {
//        await context.Response.WriteAsync("In Map3");
//    });
//});

app.UseEndpoints(endpoints =>
{
    //add your endpoints here
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In file - {fileName} - {extension}");
    });

    endpoints.Map("employee/profile/{EmployeeName:length(4,7):alpha=shrey}", async context =>
    {
        string? empName = Convert.ToString(context.Request.RouteValues["EmployeeName"]);
        await context.Response.WriteAsync($"In Employee - {empName}");
    });

    endpoints.Map("products/details/{id:int:range(1,1000)?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            var id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"productDetails for id = {id}");
        }
        else
        {            
            await context.Response.WriteAsync("productDetails - id is not supplied");
        }
        
    });

});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request recived at {context.Request.Path}");
});

app.Run();
