using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using WeblearnApi_Nihira.Modal;
using WeblearnApi_Nihira.Service;

namespace WeblearnApi_Nihira.Controllers
{
  [Authorize]
 [EnableRateLimiting("fixedwindow")]
  [Route("api/[controller]")]
 [ApiController]
 public class CustomerController : ControllerBase
 {
  private readonly ICustomerService _service;

  public CustomerController(ICustomerService service)
  {
   _service = service;
  }

  //[EnableCors("corspolicy1")]
  [HttpGet("GetAll")]
  public async Task<IActionResult> GetAll()
  {
   var data =await _service.GetAllAsync();
   if (data==null)
   {
    return NotFound();
   }
   return Ok(data);
  }

  [DisableRateLimiting]
  [HttpGet("GetByCode")]
  public async Task<IActionResult> GetByCode(string code)
  {
   var data =await _service.GetByCodeAsync(code);
   if (data==null)
   {
    return NotFound();
   }
   return Ok(data);
  }

  [HttpPost("Create")]
  public async Task<IActionResult> Create(CustomerModal _data)
  {
   var data = await _service.Create(_data);
   return Ok(data);
  }
    [HttpPut("Update")]
  public async Task<IActionResult> Update(CustomerModal _data, string code)
  {
   var data = await _service.Update(_data,code);
   return Ok(data);
  }
  [HttpDelete("Remove")]
  public async Task<IActionResult> Remove(string code)
  {
   var data = await _service.Remove(code);
   return Ok(data);
  }





 }
}
// Middleware  
// A middleware is nothing but a component(class) which is executet on every request in ASP.NET Core application
//Middlware components(classes) are executet in order they are  added to the pipeline
//Middlware can be build-in as part of .Net core framework, added via Nugget Packages or can be custom middleware
//
//Dependect injection is the inbuild feature in .net core 
// it provides 3 ways to register DI to service
//Transient - it creates an instance each time they are requseted and are never shared. It is used mainly for lightweight stateless services
// Singlton this create only single instances which are shared amoung  all components that require it 
//Scoped it creates an instance once per scope which is created on every request to the application
//Entity Framework Core is   an object-relational mapper O/RM and provides three approaches to create entity model

//Database first, code first, model first


//Cross origin resource sharing// blocking one domain using another domain
// is a browser security feature that restricts cross origin Http request
//if your rest api's resource receive non simple cross origin http requests you need to enable cors support
// [EnableCors("corspolicy1")]

//Rate Limiting is a strategy for limiting network traffic
//can help us to stop kinds of malicious bot activity
// it can also reduce strain on web servers

//[DisableCors]// mostly no need for this

//Authentication is the process of validating user identity
// Authorization is the process of providing permission to access the resources
//Authentication is used to protect our application data from unauthorized access

//Basic Authentication 
// -sends user names and passwords over the internet as text that is base64 encoded and the target server is not authenticated 
// this form of authentication can expose user names and passwords if someone can intercept the transmission , the user name and password information can easily be decoded


//JWT Authentication 
//JSON web tokens are an open standard which is defined in JSON web token . Specification RFc 7519
//They securely represent  claims between two parties

//Refresh Token
//A refresh token is a special token that is used to obtain additional access tokens.
//This allows you to have short lived access tokens without having to collect credentials every time one expires

//Image Handling
//Upload 
//Retrieve 
//Remove
//Download Images