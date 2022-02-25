using Microsoft.EntityFrameworkCore;

namespace ApiApp.Models;

public record Fruit
{
    public string Name { get; set; }
    public string Ripeness { get; set; }

    public Fruit(string name, string ripeness)
    {
        Name = name;
        Ripeness = ripeness;
    }
}

public class YoshiContext : DbContext
{
    public DbSet<Yoshi> Yoshis { get; set; }

    public string DbPath { get; }
    
    public YoshiContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "yoshi.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)  
    {  
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Yoshi>().OwnsOne(y => y.FavoriteFruit);
    }  
}


public class Yoshi
{
    public int Id { get; set; }
    public string Color { get; set; }
    public string ShoeColor { get; set; }
    public Fruit FavoriteFruit { get; set;  }


    public Yoshi(int id, string color, string shoeColor, Fruit favoriteFruit)
    {
        Id = id;
        Color = color;
        ShoeColor = shoeColor;
        FavoriteFruit = favoriteFruit;
    }
}