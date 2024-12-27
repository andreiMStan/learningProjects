using CloudCustomers.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.Api.Controllers
{
 [ApiController]
 [Route("[controller]")]
 public class UsersController : ControllerBase
 {
  private readonly IUserService _userService;

  public UsersController(IUserService userService)
  {
   _userService = userService;
  }

  [HttpGet("GetUsers")]
 
  public async Task<IActionResult>Get()
  {
   var users = await _userService.GetAllUsers();
   if (users.Any())
   {
   return Ok(users);
   }
   return NotFound();
  }
 }
}