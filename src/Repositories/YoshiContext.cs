using ApiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ApiApp.Repositories;

public class YoshiContext : DbContext
{
    public DbSet<Yoshi> Yoshis { get; set; }
    public DbSet<Fruit> Fruits { get; set; }


    // public YoshiContext(DbContextOptions<YoshiContext> options)
    // : base(options)
    // {
    //     
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        Console.WriteLine("Hi from within OnModelCreating!");
        
        // var yoshiSeed = new List<Yoshi> {
        //     new Yoshi
        //     {
        //         YoshiId = 11,
        //         Color = "Blue",
        //         FruitId = 1,
        //         ShoeColor = "Pink"
        //     },
        //     new Yoshi
        //     {
        //         YoshiId = 22,
        //         Color = "Red",
        //         FruitId = 1,
        //         ShoeColor = "Green"
        //     },
        //     new Yoshi
        //     {
        //         YoshiId = 33,
        //         Color = "Green",
        //         FruitId = 1,
        //         ShoeColor = "Brown"
        //     }
        // };

        modelBuilder.Entity<Fruit>()
            .HasData(
                new
                {
                    FruitId = 1,
                    Name = "Apple"
                }
            );
        
        modelBuilder.Entity<Yoshi>()
            .HasData(
                new Yoshi
                {
                    YoshiId = 11,
                    Color = "Blue",
                    ShoeColor = "Pink"
                },
                new Yoshi
                {
                    YoshiId = 22,
                    Color = "Red",
                    ShoeColor = "Green"
                },
                new Yoshi
                {
                    YoshiId = 33,
                    Color = "Green",
                    ShoeColor = "Brown"
                });
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Test");
        
    }
    
    
}
