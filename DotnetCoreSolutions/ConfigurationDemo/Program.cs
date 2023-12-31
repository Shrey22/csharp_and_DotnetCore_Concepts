var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/", async context =>
//    {
//        await context.Response.WriteAsync(app.Configuration["MyKey"] + "\n");
//        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n");
//        await context.Response.WriteAsync(app.Configuration.GetValue<int>("SysCode") + "\n");
//    });
//});
app.MapControllers();
app.Run();
