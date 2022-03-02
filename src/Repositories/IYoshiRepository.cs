using ApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiApp.Repositories;

public interface IYoshiRepository
{

    public IQueryable<Yoshi> GetAllYoshi();
    
    public Yoshi? GetYoshiById(int id);

    public void CreateYoshi(Yoshi yoshi);

    public string test();
}