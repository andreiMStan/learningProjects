﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToDoMauiApp.Models;

namespace ToDoMauiApp.DataServices
{
				public class RestDataService : IRestDataService

				{
								private readonly HttpClient _httpClient;
								private readonly string _baseAddress;
								private readonly string _url;
								private readonly JsonSerializerOptions _jsonSerializerOptions;
        public RestDataService()
        {
												//HttpClient _httpClient
												_httpClient = new HttpClient();
												_baseAddress = DeviceInfo.Platform == DevicePlatform.Android ?
																"http://10.0.2.2:5041" : "https://localhost:7040";
												_url = $"{_baseAddress}/api";
												_jsonSerializerOptions = new JsonSerializerOptions
												{
																PropertyNamingPolicy = JsonNamingPolicy.CamelCase
												};
        }
        public async Task AddToDoAsync(ToDo toDo)
								{
												if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
												{
																Debug.WriteLine("-----> No Internet Access...");
																return;
												}
												try
												{
																string jsonToDo = JsonSerializer.Serialize<ToDo>(toDo, _jsonSerializerOptions);
																StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");
																
																HttpResponseMessage response= await _httpClient.PostAsync($"{_url}/todo",content);

																if (response.IsSuccessStatusCode)
																{
																				Debug.WriteLine("Successfully created ToDo");
																}
																else
																{
																				Debug.WriteLine("Non Http 2xx response");
																}


												}
												catch (Exception ex)
												{
																Debug.WriteLine($"Whoops exception: {ex.Message}");

													
												}
								}

								public async Task DeleteToDoAsync(int id)
								{
												if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
												{
																Debug.WriteLine("-----> No Internet Access...");
																return;
												}
												try
												{

																HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/todo/{id}");
																if (response.IsSuccessStatusCode)
																{
																				Debug.WriteLine("Successfully created ToDo");
																}
																else
																{
																				Debug.WriteLine("Non Http 2xx response");
																}
												}
												catch (Exception ex)
												{
																Debug.WriteLine($"Whoops exception: {ex.Message}");
												}
								}

								public async Task<List<ToDo>> GetAllToDosAsync()
								{
												List<ToDo> todos =new List<ToDo>();
												if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
												{
																Debug.WriteLine("-----> No Internet Access...");
																return todos;
													}
												try
												{
																HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/todo");

																if (response.IsSuccessStatusCode)
																{
																				string content = await response.Content.ReadAsStringAsync();
																				todos = JsonSerializer.Deserialize<List<ToDo>>(content, _jsonSerializerOptions);
																}
																else
																{
																				Debug.WriteLine("-----> Non Http 2xx  response");

																}
												}
												catch (Exception ex)
												{
																Debug.WriteLine($"Whoops exception: {ex.Message}");

												}
												return todos;
								}

								public async Task UpdateToDoAsync(ToDo toDo)
								{
												if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
												{
																Debug.WriteLine("-----> No Internet Access...");
																return;
												}
												try
												{
																string jsonToDo = JsonSerializer.Serialize<ToDo>(toDo, _jsonSerializerOptions);
																StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");

																				HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/todo/{toDo.Id}", content);

																if (response.IsSuccessStatusCode)
																{
																				Debug.WriteLine("Successfully created ToDo");
																}
																else
																{
																				Debug.WriteLine("Non Http 2xx response");
																}


												}
												catch (Exception ex)
												{
																Debug.WriteLine($"Whoops exception: {ex.Message}");


												}
								}
				}
}
