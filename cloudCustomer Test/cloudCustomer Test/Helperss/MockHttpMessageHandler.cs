using CloudCustomers.Api.Models;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudCustomer_Test.Helperss
{
 internal class MockHttpMessageHandler<T>
 {
  internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)
   //creating a method to return fully setup mockhandler that returns some expected response for us
  {
   var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
   {
    Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
   };

   mockResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

   var handlerMock = new Mock<HttpMessageHandler>();

   handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
    ItExpr.IsAny<HttpRequestMessage>(),
    ItExpr.IsAny<CancellationToken>()).ReturnsAsync(mockResponse);

   return handlerMock;
  }




  internal static Mock<HttpMessageHandler>  SetupBasicGetResourceList(List<User> expectedResponse, string endpoint)
  {
   var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
   {
    Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
   };

   mockResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

   var handlerMock = new Mock<HttpMessageHandler>();

   var httpRequestMessage = new HttpRequestMessage
   {
    RequestUri = new Uri(endpoint),
    Method = HttpMethod.Get
   };
   handlerMock.Protected().Setup<Task<HttpResponseMessage>>
    ("SendAsync",
    ItExpr.IsAny<HttpRequestMessage>(),
    ItExpr.IsAny<CancellationToken>()).ReturnsAsync(mockResponse);

   return handlerMock;
  }

  internal static Mock<HttpMessageHandler> SetupReturn404()
  {
   var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound) 
   {
    Content = new StringContent("")
   };

   mockResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

   var handlerMock = new Mock<HttpMessageHandler>();

   handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
    ItExpr.IsAny<HttpRequestMessage>(),
    ItExpr.IsAny<CancellationToken>()).ReturnsAsync(mockResponse);

   return handlerMock;
  }
 }
}
