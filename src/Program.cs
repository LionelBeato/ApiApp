using ApiApp.Models;
using ApiApp.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<YoshiContext>(op => 
    op.UseInMemoryDatabase("Test"));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
