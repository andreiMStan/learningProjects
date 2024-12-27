
using cloudCustomer_Test.Helperss;
using CloudCustomers.Api.Config;
using CloudCustomers.Api.Fixtures;
using CloudCustomers.Api.Models;
using CloudCustomers.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace cloudCustomer_Test.Services
{
 public class TestUsersService
 {
  [Fact]
  public async Task GetAllUsers_WhenCalled_InvokeHttpGetRequest()
  {
   //Arrange
   var expectedResponse = UsersFixture.GetTestUsers();
   var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);

   var httpClient = new HttpClient(handlerMock.Object);
   var endpoint = "https://test.com";
   var config = Options.Create(new UserApiOption 
   { Endpoint = endpoint });

   var sut = new UserService(httpClient,config);

   //Act
   await sut.GetAllUsers();

   //Assert
   handlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
    ItExpr.IsAny<CancellationToken>());
   //Verify that a http is made!


  }



  [Fact]
  public async Task GetAllUsers_WhenCalled_ReturnsListOfUsers()
  {
   //Assert

   var expectedResponse = UsersFixture.GetTestUsers();
   var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
   var httpClient = new HttpClient(handlerMock.Object);
   var endpoint = "https://test.com";
   var config = Options.Create(new UserApiOption { Endpoint = endpoint });

   var sut = new UserService(httpClient, config);

   //Act
   var result = await sut.GetAllUsers();

   //Assert 
   result.Should().BeOfType<List<User>>();
  }




  [Fact]
  public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
  {
   //Assert

   var expectedResponse = UsersFixture.GetTestUsers();
   var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
   var httpClient = new HttpClient(handlerMock.Object);
   var endpoint = "https://test.com";
   var config = Options.Create(new UserApiOption { Endpoint = endpoint });

   var sut = new UserService(httpClient, config);

   //Act
   var result = await sut.GetAllUsers();

   //Assert 
   result.Count.Should().Be(0);
  }



  [Fact]
  public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpectedSize()
  {
   //Assert

   var expectedResponse = UsersFixture.GetTestUsers();
   var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
   var httpClient = new HttpClient(handlerMock.Object);
   var endpoint = "https://test.com";
   var config = Options.Create(new UserApiOption { Endpoint = endpoint });

   var sut = new UserService(httpClient, config);

   //Act
   var result = await sut.GetAllUsers();

   //Assert 
   result.Count.Should().Be(expectedResponse.Count);
  }



  [Fact]
  public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
  {
   //Assert

   var expectedResponse = UsersFixture.GetTestUsers();
   var endpoint = "https://test.com/users";
   var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse,endpoint);
   var httpClient = new HttpClient(handlerMock.Object);


   var config = Options.Create(new UserApiOption {
    Endpoint= endpoint
   });
   
   var sut = new UserService(httpClient,config);
   
   //Act

   var result = await sut.GetAllUsers();
   var uri = new Uri(endpoint);
   
   //Assert 
   handlerMock
    .Protected()
    .Verify(
    "SendAsync",
    Times.Exactly(1),
    ItExpr.Is<HttpRequestMessage>(
     req=>req.Method==HttpMethod.Get&& 
     req.RequestUri==uri), 
    ItExpr.IsAny<CancellationToken>())
    ;
  }
 }
}
