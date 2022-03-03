using ApiApp.Models;
using ApiApp.Repositories;
using ApiApp.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class YoshiController : ControllerBase
{

    private IYoshiService _yoshiService; 

    public YoshiController(IYoshiService yoshiService)
    {
        _yoshiService = yoshiService; 
    }

    [HttpGet]
    public List<Yoshi> GetAllYoshi()
    {
        // navigation props are null by default due to lazy loading
        // you must specify include() in order to enable eager loading 
        // return yoshiContext.Yoshis.Include(y => y.Fruit); 
        return _yoshiService.GetAllYoshis(); 
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetYoshiById(int id)
    {
        // add in NotFound()
        return Ok(_yoshiService.GetYoshiById(id)); 
    }
    
    [HttpPost]
    public void AddYoshi(Yoshi yoshi)
    { 
        _yoshiService.SaveYoshi(yoshi); 
    }

}