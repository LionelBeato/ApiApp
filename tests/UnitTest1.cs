using ApiApp.Models;
using ApiApp.Service;
using Moq;
using NUnit.Framework;

namespace tests;

public class Tests
{
    private Mock<IYoshiService> _yoshiService; 

    [SetUp]
    public void Setup()
    {
        _yoshiService = new Mock<IYoshiService>(); 
    }

    [Test]
    public void Test1()
    {
        _yoshiService.Setup(x => x.HelloWorld()).Returns("Hello World!"); 
        var expected = "Hello World!";

        _yoshiService.Object.HelloWorld();
        _yoshiService.Verify(x => x.HelloWorld()); 
        
        // Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void Test2()
    {
        // Yoshi myYoshi = new Yoshi(1, "Blue", "Black", new Fruit("Passion Fruit", "ripe"));
    }
}