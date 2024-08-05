using DotNetCoreRepoPatternDI.Data.Models;
using DotNetCoreRepoPatternDI.Services;
using DotNetCoreRepoPatternDI.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AtcgsaWithoutAspnetauthContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();


// DI
builder.Services.AddTransient<ITransient, DependancyInjectionDemoClass>(); // per service called
builder.Services.AddScoped<IScoped, DependancyInjectionDemoClass>();// Per browser
builder.Services.AddSingleton<ISingleton, DependancyInjectionDemoClass>(); // Only one time when system load

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();




// Controller >>Service >> Model >> 

// Model >> DB connection
// Service >> DB connection
