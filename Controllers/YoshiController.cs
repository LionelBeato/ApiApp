using ApiApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class YoshiController
{
    private static readonly string[] Colors = new[]
    {
        "Blue", "Red", "Brown", "Yellow", "Pink", "Black", "White", "Orange", "Green"
    };

    private static readonly string[] Fruits = new[]
    {
        "Banana", "Apple", "Grape", "Pear", "Passionfruit", "Starfruit"
    };

    private static readonly string[] Ripeness = new[]
    {
        "Unripe", "Ripe", "Somewhat Ripe", "Really Ripe"
    };


    [HttpGet(Name = "yoshi")]
    public IEnumerable<Yoshi> GetAllYoshi()
    {
        return Enumerable.Range(1, 5)
            .Select(index => new Yoshi(
                index,
                Colors[Random.Shared.Next(Colors.Length)],
                Colors[Random.Shared.Next(Colors.Length)],
                new Fruit(Fruits[Random.Shared.Next(Fruits.Length)],
                Ripeness[Random.Shared.Next(Ripeness.Length)])))
            .ToArray();
    }

    // TODO: Add Yoshi
    // TODO: Get One Yoshi
    // TODO: Delete Yoshi
    // TODO: Update Yoshi

}