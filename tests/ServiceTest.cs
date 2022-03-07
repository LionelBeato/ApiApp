using System.Collections.Generic;
using ApiApp.Models;
using ApiApp.Repositories;
using ApiApp.Service;
using Moq;
using NUnit.Framework;

namespace tests;

public class ServiceTest
{
    
    private Mock<IYoshiRepository> _repository;
    private YoshiService _service; 

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IYoshiRepository>();
        _service = new YoshiService(_repository.Object); 
    }
    
    [Test]
    public void GivenIdOfOne_WhenGetYoshiByIdCalled_ThenReturnYoshi()
    {

        const int id = 1;
        var yoshi = new Yoshi( "black", "red") {YoshiId = id};
            // sets up an expectation for this object's method call 
        // all dependant objects will act in accordance to this setup
        _repository.Setup(r => r.GetYoshiById(id))
            .Returns(yoshi);

        Assert.AreEqual(_service.GetYoshiById(id), yoshi); 
        _repository.Verify();


    }

    [Test]
    public void GivenRepo_WhenGetAllIsCalled_ReturnAllYoshis()
    {
        var yoshis = new List<Yoshi>
        {
            new Yoshi ("black",  "red"),
            new Yoshi ("black",  "red")


        };

        _repository.Setup(r => r.GetAllYoshi()).Returns(yoshis); 
        
        Assert.AreEqual(_service.GetAllYoshis(), yoshis);
    }

    [Test]
    public void EqualityCheck()
    {
        var y1 = new Yoshi("black", "red");
        var y2 = new Yoshi("black", "red");
        
        Assert.AreEqual(y1, y2);
    }

}