using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Moh.Controllers;
using Unit_Moh.Models;
using Unit_Moh.Services.Interfaces;
using XunitFans.Fixtures;

namespace XunitFans.Systems.Controllers
{
 //Moq allows mimic of a behavior of a dependency


 //Congratulation to me for writing first XUnit Test 
 public class TestFansController
 {
  [Fact]
                    //the action _ the condition
  public async Task Get_OnSucces_ReturnStatusCode200()
  {
   //Arange - setting up the task(the environment in which my test run, what it needs ) (requirement , dependency

   //declared a new service that I want to mock
   //setting it up saying when I call the getallfans service return a list of fans(returning empty list)
   var mockFanService = new Mock<IFanService>();
   mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(FansFixtures.GetFans());

   var fansController = new FansController(mockFanService.Object);


   //Act -excuting the action inside my controller and getting a result

   //this is returning a IActionResult -> needs casting for a http return , converting in ok object result
   var result =(OkObjectResult) await fansController.Get();

   //Assert // making sure that is the result that I need

   result.StatusCode.Should().Be(200); 
  }
  [Fact]
  public async Task Get_OnSuccess_InvokeService()
  {
   //Arrange
   var mockFanService = new Mock<IFanService>();
   mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(FansFixtures.GetFans());

   var fansController = new FansController(mockFanService.Object);

   //Act
   var result = (OkObjectResult)await fansController.Get();

   //Assert
   mockFanService.Verify(service => service.GetAllFans(), Times.Once);
  }

  [Fact]
  public async Task Get_OnSuccess_ReturnListOfFans()
  {
   //Arrange
   var mockFanService = new Mock<IFanService>();
   mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(FansFixtures.GetFans());

   var fansController = new FansController(mockFanService.Object);

   //Act
   var result = (OkObjectResult)await fansController.Get();

   //Assert
   //verifying the type
   result.Should().BeOfType<OkObjectResult>();
   //the value is a list of fans 
   result.Value.Should().BeOfType<List<Fan>>();
  }

  [Fact]
  public async Task Get_OnNoFans_ReturnNotFound()
  {
   //Arrange
   var mockFanService = new Mock<IFanService>();
   mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(new List<Fan>());

   var fansController = new FansController(mockFanService.Object);

   //Act
   var result = (NotFoundResult)await fansController.Get();


   //Assert
   result.Should().BeOfType<NotFoundResult>();

  }

 }
}
