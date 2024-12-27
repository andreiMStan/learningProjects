using Microsoft.Extensions.Options;
using System.Net;
using Unit_Moh.Configuration;
using Unit_Moh.Models;
using Unit_Moh.Services.Interfaces;

namespace Unit_Moh.Services
{
 public class FanService : IFanService

 {
  private readonly HttpClient _httpClient;
  private readonly ApiServiceConfig _config;
  public FanService(HttpClient httpClient, IOptions<ApiServiceConfig> config)
  {
   _httpClient = httpClient;
   _config = config.Value;
  }
  public async Task<List<Fan>?> GetAllFans()
  {

   //switch statement can be implemented
   var response = await _httpClient.GetAsync(_config.Url);
   //if (response.StatusCode == HttpStatusCode.NotFound)
   switch (response.StatusCode)
   {
    case HttpStatusCode.NotFound:
     return new List<Fan>();// throw anything but here a empty list
    case HttpStatusCode.Unauthorized:
     return null;

    default:
     {
      var fans = await response.Content.ReadFromJsonAsync<List<Fan>>();
      return fans;
     }

   }
  }
 }
}