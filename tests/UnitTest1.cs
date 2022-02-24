using ApiApp.Service;
using NUnit.Framework;

namespace tests;

public class Tests
{
    private YoshiService _yoshiService; 

        [SetUp]
    public void Setup()
    {
        _yoshiService = new YoshiService(); 
    }

    [Test]
    public void Test1()
    {
        var expected = "Hello World!";
        var actual = _yoshiService.HelloWorld(); 
        
        Assert.AreEqual(expected, actual);
    }
}