using ApiApp.Models;

namespace ApiApp.Service;


public interface IYoshiService
{
    string HelloWorld(); 
    
    // get 
    public List<Yoshi> GetAllYoshis();

    public Yoshi? GetYoshiById(int id); 
    // put 
    
    // post
    public void SaveYoshi(Yoshi yoshi);
    
    // delete
    public void DeleteYoshi(int id); 
}