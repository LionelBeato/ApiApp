using ApiApp.Models;
using ApiApp.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiApp.Controllers;




[ApiController]
[Route("[controller]")]
public class YoshiController
{

    private YoshiContext yoshiContext;

    public YoshiController()
    {
        var options = new DbContextOptionsBuilder<YoshiContext>()
            .UseInMemoryDatabase("Test")
            .Options;


        yoshiContext = new YoshiContext(options);
    }

    [HttpGet]
    public IQueryable GetAllYoshi()
    {
        // navigation props are null by default due to lazy loading
        // you must specify include() in order to enable eager loading 
        return yoshiContext.Yoshis.Include(y => y.Fruit); 
    }

    [HttpGet("/Fruit")]
    public DbSet<Fruit> GetAllFruit()
    {
        return yoshiContext.Fruits; 
    }

    [HttpPost("/Fruit")]
    public void AddFruit(Fruit fruit)
    {
        yoshiContext.Fruits.Add(fruit);
        yoshiContext.SaveChanges(); 
    }

    // TODO: Add Yoshi

    [HttpPost]
    public void AddYoshi(Yoshi yoshi)
    {
        yoshiContext.Yoshis.Add(yoshi);
        yoshiContext.SaveChanges(); 
    }
    
    // TODO: Fix issue where navigation property doesn't reference already added Fruits
    
    // TODO: Get One Yoshi
    // TODO: Delete Yoshi
    // TODO: Update Yoshi

}