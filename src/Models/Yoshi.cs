using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiApp.Models;


public class Fruit
{
    public int FruitId { get; set; }
    public string Name { get; set; }
    
}

public class Yoshi
{
    public int YoshiId { get; set; }
    public string Color { get; set; }
    public string ShoeColor { get; set; }
    public int FruitId { get; set; }
    public Fruit Fruit { get; set;  }

}