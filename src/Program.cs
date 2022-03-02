using ApiApp.Models;
using ApiApp.Repositories;
using Microsoft.EntityFrameworkCore;


// var options = new DbContextOptionsBuilder<YoshiContext>().UseInMemoryDatabase("Test").Options; 
//
// using (var context = new YoshiContext(options))
// {
//     var yoshiSeed = new List<Yoshi> {
//         new Yoshi
//         {
//             YoshiId = -1,
//             Color = "Blue",
//             FruitId = 1,
//             ShoeColor = "Pink"
//         },
//         new Yoshi
//         {
//             YoshiId = -2,
//             Color = "Red",
//             FruitId = 1,
//             ShoeColor = "Green"
//         },
//         new Yoshi
//         {
//             YoshiId = -3,
//             Color = "Green",
//             FruitId = 1,
//             ShoeColor = "Brown"
//         }
//     };
//     
//     context.Yoshis.AddRange(yoshiSeed);
//     context.SaveChanges(); 
// }

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<YoshiContext>();
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
