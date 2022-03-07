namespace ApiApp.Models;

public record Fruit (string Name)
{
    public int FruitId { get; init; }
}