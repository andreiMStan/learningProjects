using CloudCustomers.Api.Controllers;
using CloudCustomers.Api.Fixtures;
using CloudCustomers.Api.Models;
using CloudCustomers.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace cloudCustomer_Test
{
 public class TestUsersController
 {
  [Fact]
  public  async Task Get_OnSucces_ReturnsStatusCode200()
  {
   //Arrange //sut=system under test
   var mockUsersService = new Mock<IUserService>();

   mockUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(UsersFixture.GetTestUsers());


   var sut = new UsersController(mockUsersService.Object);

   //Act
   var result = (OkObjectResult) await sut.Get();

   //Assert
   result.StatusCode.Should().Be(200);

  }

  [Fact]
  public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
  {
   //Arrange 
   var mockUsersService = new Mock<IUserService>();

   //controll the behavior of DI ,to follow particular path 
   mockUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(UsersFixture.GetTestUsers());


   var sut = new UsersController(mockUsersService.Object);

   //Act

   var result = await sut.Get();

   //Assert

   mockUsersService.Verify(
    service => service.GetAllUsers(),
               Times.Once());

  }

  [Fact]
  public async Task Get_OnSucces_ReturnsListOfUsers()
  {
   //Arrange
   var mockUsersService = new Mock<IUserService>();

   mockUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(UsersFixture.GetTestUsers());

   var sut = new UsersController(mockUsersService.Object);

   //Act
   var result= await sut.Get();
   //Assert
   result.Should().BeOfType<OkObjectResult>();
   var objectResult = (OkObjectResult)result;
   objectResult.Value.Should().BeOfType<List<User>>();
  }

  [Fact]
  public async Task Get_OnNoUsersFound_Returns404()
  {
   //Arrange
   var mockUsersService = new Mock<IUserService>();
   mockUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());

   var sut = new UsersController(mockUsersService.Object);

   //Act
   var result = await sut.Get();

   //Assert
   result.Should().BeOfType<NotFoundResult>();
   var objectResult = (NotFoundResult)result;
   objectResult.StatusCode.Should().Be(404);
  }
 
 }
}
