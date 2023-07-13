using PersonService;
using PersonServiceContract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//add our custom services
//builder.Services.Add( new ServiceDescriptor(typeof(IPersonService), typeof(PeopleService), ServiceLifetime.Transient) );
//builder.Services.Add(new ServiceDescriptor(typeof(IPersonService), typeof(PeopleService), ServiceLifetime.Singleton));
builder.Services.Add(new ServiceDescriptor(typeof(IPersonService), typeof(PeopleService), ServiceLifetime.Scoped));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
