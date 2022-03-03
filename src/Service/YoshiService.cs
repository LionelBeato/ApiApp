using ApiApp.Models;
using ApiApp.Repositories;

namespace ApiApp.Service;

public class YoshiService : IYoshiService
{
    private IYoshiRepository _repository;

    public YoshiService(IYoshiRepository repository)
    {
        _repository = repository; 
    }
    
    
    public string HelloWorld()
    {
        return "Hello World!"; 
    }

    public Yoshi? GetYoshiById(int id)
    {
        return _repository.GetYoshiById(id); 
    }

    public List<Yoshi> GetAllYoshis()
    {
        return _repository.GetAllYoshi(); 
    }

    public void DeleteYoshi(int id)
    {
        var yoshi = GetYoshiById(id);
        _repository.DeleteYoshi(yoshi); 
    }

    public void SaveYoshi(Yoshi yoshi)
    {
        _repository.CreateYoshi(yoshi);
    }
}