namespace ApiApp.Models;

public record Fruit (string Name)
{
    public int FruitId { get; init; }
    // public string Name { get; set; }
    // public List<Yoshi> Yoshis { get; set; }

}