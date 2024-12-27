using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;



namespace XunitFans.Helpers
{
 public class MockHttpHandler<T>
 {
  //success
  internal static Mock<HttpMessageHandler> SetupGetRequest(List<T> response)
  {

   //creating the mock response that we currently have 
   //returning http object of 200/ok
   var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
   {
    //serializing the response into content
    Content = new StringContent(JsonConvert.SerializeObject(response))
   };

   //specifying the type of the content (json)
   mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


   //set up a nue httpmessagehandler 

   var mockHandler = new Mock<HttpMessageHandler>();

   //making it protected  because we are utilizing the mock library 
   // we are duing the setup
   //specifying type of response 
   //make sure is a task
   //method propriety is send async
   mockHandler.Protected().Setup<Task<HttpResponseMessage>>(
    "SendAsync",
    ItExpr.IsAny<HttpRequestMessage>(),
       // ItExpr.IsAny<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
    ItExpr.IsAny<CancellationToken>()).ReturnsAsync(mockResponse);

    //parameters return any type of message and cancellation token
   return mockHandler;

   //we have mimic the response back to our system  
   // we don't do any http calls
  }

  //NotFound
  internal static Mock<HttpMessageHandler> SetupReturnNotFound()
  {
   var mockResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
   {
    Content = new StringContent("")
   };
   mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

   var mockHandler = new Mock<HttpMessageHandler>();
   mockHandler.Protected().Setup<Task<HttpResponseMessage>>
    ("SendAsync",
   ItExpr.IsAny<HttpRequestMessage>(),
    ItExpr.IsAny<CancellationToken>()).ReturnsAsync(mockResponse);

   return mockHandler;
  }
 }
}