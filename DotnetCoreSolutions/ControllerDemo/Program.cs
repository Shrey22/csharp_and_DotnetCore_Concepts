using ControllerDemo.Controllers;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<HomeController>();  //this will add only mentioned controller
builder .Services.AddControllers(); // adds all the controllers classes as services

var app = builder.Build();
app.UseStaticFiles();
//use controllers for endpoints
app.UseRouting();
app.MapControllers();

app.Run();
