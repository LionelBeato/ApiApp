using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;

namespace ApiApp.Models;

public record Yoshi(string Color, string ShoeColor)
{
    public int YoshiId { get; init; }
}; 