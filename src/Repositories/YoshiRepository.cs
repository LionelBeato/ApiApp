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
    private YoshiContext _yoshiContext;
    
    public YoshiRepository (YoshiContext yoshiContext)
    {
        _yoshiContext = yoshiContext;
    }

    public List<Yoshi> GetAllYoshi()
    {
        return _yoshiContext.Yoshis.ToList();
    }

    public Yoshi? GetYoshiById(int id)
    {
        return _yoshiContext.Yoshis.FirstOrDefault(y => y.YoshiId.Equals(id)); 
    }
    
    public void CreateYoshi(Yoshi yoshi)
    { _yoshiContext.Yoshis.Add(yoshi);
        _yoshiContext.SaveChanges(); 
    }

    public void DeleteYoshi(Yoshi yoshi)
    {
        _yoshiContext.Yoshis.Remove(yoshi); 
    }

    public string test()
    {
        return "hello world!"; 
    }
    
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _yoshiContext.Dispose();
            }
        }
        this.disposed = true;
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}