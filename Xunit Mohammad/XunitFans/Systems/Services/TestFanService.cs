using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Unit_Moh.Configuration;
using Unit_Moh.Models;
using Unit_Moh.Services;
using XunitFans.Fixtures;
using XunitFans.Helpers;

namespace XunitFans.Systems.Services
{
 public class TestFanService
 {
  [Fact]
  public async Task GetAllFans_OnInvoked_HttpGet()
  {
   //Arange
   //mimic url that we are connecting to
   var url = "https://andrei.com/api/v1/fans";
   var response = FansFixtures.GetFans();

   //mimic the proccesing
   var mockHandler = MockHttpHandler<Fan>.SetupGetRequest(response);

   //than injecting into http client
   //httpclient will think that is connection to a third pary service  rather than doing the call
   var httpClient = new HttpClient(mockHandler.Object);


   var config = Options.Create(new ApiServiceConfig()
   {
    Url = url
   });
   var fanService = new FanService(httpClient,config);


   //Act
   await fanService.GetAllFans();

   //Assert
   mockHandler.Protected().Verify(
    "SendAsync", Times.Once(),
    ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString() == url),
    ItExpr.IsAny<CancellationToken>());

  }


  [Fact]
  public async Task GetAllFans_OnInvoked_GetListOfFans()
  {
   //Arange
   //mimic url that we are connecting to
   var url = "https://andrei.com/api/v1/fans";
   var response = FansFixtures.GetFans();

   //mimic the proccesing
   var mockHandler = MockHttpHandler<Fan>.SetupGetRequest(response);

   //than injecting into http client
   //httpclient will think that is connection to a third pary service  rather than doing the call
   var httpClient = new HttpClient(mockHandler.Object);

   var config = Options.Create(new ApiServiceConfig()
   {
    Url = url
   });
   var fanService = new FanService(httpClient, config);


   //Act
   var result=await fanService.GetAllFans();

   //Assert
   result.Should().BeOfType<List<Fan>>();
  }


  [Fact]
  public async Task GetAllFans_OnInvoked_ReturnEmptyList()
  {
   //Arange
   //mimic url that we are connecting to
   var url = "https://andrei.com/api/v1/fans";

   //mimic the proccesing
   var mockHandler = MockHttpHandler<Fan>.SetupReturnNotFound();

   //than injecting into http client
   //httpclient will think that is connection to a third pary service  rather than doing the call
   var httpClient = new HttpClient(mockHandler.Object);

   var config = Options.Create(new ApiServiceConfig()
   {
    Url = url
   });
   var fanService = new FanService(httpClient, config);


   //Act
   var result = await fanService.GetAllFans();

   //Assert
   result.Count.Should().Be(0);
  }

 }
}

