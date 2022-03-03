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
        var yoshi = new Yoshi {Color = "red", ShoeColor = "black", YoshiId = id}; 
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
            new Yoshi {Color = "red", ShoeColor = "black", YoshiId = 1},
            new Yoshi {Color = "blue", ShoeColor = "yellow", YoshiId = 2},

        };

        _repository.Setup(r => r.GetAllYoshi()).Returns(yoshis); 
        
        Assert.AreEqual(_service.GetAllYoshis(), yoshis);
    }

}