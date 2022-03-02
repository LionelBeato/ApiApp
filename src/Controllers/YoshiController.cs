using ApiApp.Models;
using ApiApp.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class YoshiController : ControllerBase
{

    private IYoshiRepository _repository; 

    public YoshiController(IYoshiRepository repository)
    {
        _repository = repository; 
    }

    [HttpGet]
    public List<Yoshi> GetAllYoshi()
    {
        // navigation props are null by default due to lazy loading
        // you must specify include() in order to enable eager loading 
        // return yoshiContext.Yoshis.Include(y => y.Fruit); 
        return _repository.GetAllYoshi(); 
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetYoshiById(int id)
    {
        // add in NotFound()
        return Ok(_repository.GetYoshiById(id)); 
    }
    
    // TODO: Add Yoshi
    [HttpPost]
    public void AddYoshi(Yoshi yoshi)
    { 
        _repository.CreateYoshi(yoshi); 
    }

    [HttpGet("/hello")]
    public string hello()
    {
        return _repository.test(); 
    }
    
    // TODO: Fix issue where navigation property doesn't reference already added Fruits
    
    // TODO: Get One Yoshi
    // TODO: Delete Yoshi
    // TODO: Update Yoshi

}