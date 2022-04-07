using AirlinesWay.Application;
using AirlinesWay.Application.Abstraction;
using AirlinesWay.Domain.DbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("AirlinesWay");

builder.Services.AddDbContext<AirlinesWayDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAirlineService, AirlineService>();
builder.Services.AddScoped<IFlightService, FlightService>();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();