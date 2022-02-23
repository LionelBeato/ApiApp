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

    
    [HttpGet(Name = "yoshi")]
    public IEnumerable<Yoshi> GetAllYoshi()
    {
        return Enumerable.Range(1, 5)
            .Select(index => new Yoshi(index, Colors[Random.Shared.Next(Colors.Length)], Colors[Random.Shared.Next(Colors.Length)]))
            .ToArray();
    }
}