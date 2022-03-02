using ApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiApp.Repositories;

public interface IYoshiRepository : IDisposable
{

    public List<Yoshi> GetAllYoshi();
    
    public Yoshi? GetYoshiById(int id);

    public void CreateYoshi(Yoshi yoshi);

    public string test();
}