using System.Security.Cryptography.X509Certificates;
using ApiApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ApiApp.Repositories;

// TODO: See if there is a way to simplify repository abstraction in dotnet
public class YoshiRepository : IYoshiRepository
{
    private YoshiContext yoshiContext;
    
    public YoshiRepository (YoshiContext yoshiContext)
    {
        this.yoshiContext = yoshiContext; 
    }

    public IQueryable<Yoshi> GetAllYoshi()
    {
        return yoshiContext.Yoshis.Include("Fruit");
    }

    public Yoshi? GetYoshiById(int id)
    {
        return yoshiContext.Yoshis.FirstOrDefault(y => y.YoshiId.Equals(id)); 
    }
    
    public void CreateYoshi(Yoshi yoshi)
    { yoshiContext.Yoshis.Add(yoshi);
        yoshiContext.SaveChanges(); 
    }

    public string test()
    {
        return "hello world!"; 
    }
    
    
}