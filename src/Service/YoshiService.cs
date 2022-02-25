using ApiApp.Repositories;

namespace ApiApp.Service;

public class YoshiService : IYoshiService
{
    private YoshiRepository _repository;

    public YoshiService(YoshiRepository repository)
    {
        _repository = repository; 
    }
    
    public YoshiService() {}
    
    public string HelloWorld()
    {
        return "Hello World!"; 
    }
}