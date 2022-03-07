using ApiApp.Models;
using ApiApp.Repositories;
using ApiApp.Service;
using Microsoft.EntityFrameworkCore;


var options = new DbContextOptionsBuilder<YoshiContext>().UseInMemoryDatabase("Test").Options; 

using (var context = new YoshiContext(options))
{
    var yoshiSeed = new List<Yoshi> {
        new Yoshi("Blue","Pink"),
        new Yoshi("Orange","Purple"),
    };
    
    context.Yoshis.AddRange(yoshiSeed);
    context.SaveChanges(); 
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<YoshiContext>(op => op.UseInMemoryDatabase("test"));
builder.Services.AddScoped<IYoshiService, YoshiService>();
builder.Services.AddScoped<IYoshiRepository, YoshiRepository>(); 

builder.Services.AddControllers();
// builder.Services.AddScoped<YoshiRepository>();
// builder.Services.AddTransient<YoshiRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// minimal API can be used thusly 
app.MapGet("/", () => "Hello World!"); 

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
