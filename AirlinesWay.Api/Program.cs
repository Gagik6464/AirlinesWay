using AirlinesWay.Application;
using AirlinesWay.Application.Abstraction;
using AirlinesWay.Domain.DbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("AirlinesWay");

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
builder.Services.AddDbContext<AirlinesWayDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAirlineService, AirlineService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IAirCompanyService, AirCompanyService>();
builder.Services.AddScoped<ICityService, CitiesService>();

var app = builder.Build();

using (var serviceProvider = builder.Services.BuildServiceProvider())
{
    try
    {
        var context = serviceProvider.GetRequiredService<AirlinesWayDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB");
    }
    
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cities}/{action=Index}/{id?}");

app.Run();