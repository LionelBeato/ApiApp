namespace ApiApp.Models;

public record Fruit(string Name, string Ripeness); 

public record Yoshi(int Id, string Color, string ShoeColor, Fruit FavoriteFruit);