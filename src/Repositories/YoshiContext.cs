using ApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiApp.Repositories;

public class YoshiContext : DbContext
{
    public DbSet<Yoshi> Yoshis { get; set; }
    public DbSet<Fruit> Fruits { get; set; }


    public YoshiContext(DbContextOptions<YoshiContext> options)
    : base(options)
    {
        
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Yoshi>()
    //         .HasOne(y => y.Fruit)
    //         .WithMany();
    //
    // }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseInMemoryDatabase("Test"); 
    // }
    
    
}
