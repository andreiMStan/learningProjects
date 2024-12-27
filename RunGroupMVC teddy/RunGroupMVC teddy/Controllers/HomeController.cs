using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RunGroupMVC_teddy.Helpers;
using RunGroupMVC_teddy.Interfaces;
using RunGroupMVC_teddy.Models;
using RunGroupMVC_teddy.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace RunGroupMVC_teddy.Controllers
{
 public class HomeController : Controller
 {
  private readonly ILogger<HomeController> _logger;
  private readonly IClubRepository _clubRepository;
  public HomeController(ILogger<HomeController> logger, IClubRepository clubRepository)
  {
   _logger = logger;
   _clubRepository = clubRepository;
  }
  //ip geolocation ipinfo.io
  public async Task<IActionResult> Index()
  {
   var ipInfo = new IPInfo();
   var homeViewModel = new HomeViewModel();
   try
   {
    string url = "https://ipinfo.io?token=1612405dc99294";
    var info = new WebClient().DownloadString(url);
    ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
    RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
    ipInfo.Country = myRI1.EnglishName;
    homeViewModel.City = ipInfo.City;
    homeViewModel.State = ipInfo.Region;
    if (homeViewModel.City !=null)
    {
     homeViewModel.Clubs = await _clubRepository.GetClubByCity(homeViewModel.State); 
      
    }
    else
    {
     homeViewModel.Clubs = null;
    }
    return View(homeViewModel);
   }
   catch (Exception ex)
   {
    homeViewModel.Clubs = null;
   }

   return View(homeViewModel);
  }

  public IActionResult Privacy()
  {
   return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
   return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
 }
}