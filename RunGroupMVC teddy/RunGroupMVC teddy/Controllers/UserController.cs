using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using RunGroupMVC_teddy.Interfaces;
using RunGroupMVC_teddy.Models;
using RunGroupMVC_teddy.ViewModels;

namespace RunGroupMVC_teddy.Controllers
{
 public class UserController : Controller
 {
  private readonly IUserRepository _userRepository;
  private readonly IDashboardRepository _dashboardRepository;
  private readonly IPhotoService _photoService;
  public UserController(IUserRepository userRepository, IDashboardRepository dashboardRepository, IPhotoService photoService)
  {
   _userRepository = userRepository;
   _dashboardRepository = dashboardRepository;
   _photoService = photoService;
  }

  

  [HttpGet("users")]
  public async Task<IActionResult> Index()
  {
   var users =await _userRepository.GetAllUsers();
   List<UserViewModel> result = new List<UserViewModel>();
   
    foreach (var user in users)
   {
    var userViewModel = new UserViewModel()
    {
     Id = user.Id,
     UserName = user.UserName,
     Pace = user.Pace,
     Milage = user.Milage,
     ProfileImageUrl = user.ProfileImageUrl,
    };
    result.Add(userViewModel);
   }
   return View(result);
  }

  public async Task<IActionResult> Detail(string id)
  {
   var user = await _userRepository.GetUserById(id);
   var userDetailViewModel = new UserDetailViewModel()
   {
    Id = user.Id,
    UserName = user.UserName,
    Pace=user.Pace,
    Milage=user.Milage
   };
   return View(userDetailViewModel);
  }

  
  }
 }

