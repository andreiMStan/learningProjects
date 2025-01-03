﻿using CloudCustomers.Api.Config;
using CloudCustomers.Api.Models;
using Microsoft.Extensions.Options;

namespace CloudCustomers.Api.Services
{
 //The Interface
 public interface IUserService
 {
  public Task<List<User>> GetAllUsers();
 }

 //The Service

 public class UserService : IUserService
 {
  private readonly HttpClient _httpClient;
  private readonly UserApiOption _apiConfig;

  public UserService(HttpClient httpClient,IOptions<UserApiOption>apiConfig)
  {
   _httpClient = httpClient;
   _apiConfig = apiConfig.Value;
  }

  public async Task<List<User>> GetAllUsers()
  {
   var usersResponse = await _httpClient.GetAsync(_apiConfig.Endpoint);
   if (usersResponse.StatusCode==System.Net.HttpStatusCode.NotFound)
   {
   return new List<User> { }; 

   }
   var responseContent = usersResponse.Content;
   var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
   return allUsers.ToList();
  }
 }
}
