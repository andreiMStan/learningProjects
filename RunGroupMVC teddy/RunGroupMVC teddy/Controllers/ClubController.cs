using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupMVC_teddy.Data;
using RunGroupMVC_teddy.Interfaces;
using RunGroupMVC_teddy.Models;
using RunGroupMVC_teddy.ViewModels;

namespace RunGroupMVC_teddy.Controllers
{
 public class ClubController : Controller
 {
  private readonly IClubRepository _clubrepository;
  private readonly IPhotoService _photoService;
  private readonly IHttpContextAccessor _httpContextAccessor;
  public ClubController(IClubRepository clubrepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
  {
   _clubrepository = clubrepository;
   _photoService = photoService;
   _httpContextAccessor = httpContextAccessor;
  }


  public async Task<IActionResult> Index()
  {
   //defer execution we need to have to list 
   var clubs = await _clubrepository.GetAll();
   return View(clubs);
  }

  public async Task<IActionResult> Detail(int id)
  {
   Club club = await _clubrepository.GetById(id);
   return View(club);
  }

  public IActionResult Create()
  {
   var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
   var createClubViewModel = new CreateClubViewModel 
                        { AppUserId = curUserId };
   return View(createClubViewModel);
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateClubViewModel clubVM)
  {
   if (ModelState.IsValid)
   {
    var result = await _photoService.AddPhotoAsync(clubVM.Image);

    var club = new Club
    {
     Title = clubVM.Title,
     Description = clubVM.Description,
     Image = result.Url.ToString(),
     AppUserId = clubVM.AppUserId,
     Address = new Address
     {
      Street = clubVM.Address.Street,
      City = clubVM.Address.City,
      State = clubVM.Address.State,
     }
    };
    _clubrepository.Add(club);
    return RedirectToAction("Index");
   }
   else
   {
    ModelState.AddModelError("", "Photo upload failed");
   }
   return View(clubVM);
  }
 
  public async Task<IActionResult> Edit(int id)
  {
   var club = await _clubrepository.GetById(id);

   if (club == null) return View("Error");

    var clubVM = new EditClubViewModel
    {
     Title = club.Title,
     Description = club.Description,
     AddressId = club.AddressId,
     Address = club.Address,
     AppUserId=club.AppUserId,
     Url = club.Image,
     ClubCategory = club.ClubCategory
    };
   return View(clubVM);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(int id, EditClubViewModel clubVM)
  {
   if (!ModelState.IsValid)
   {
    ModelState.AddModelError("", "Failed to edit club");
   }

   

   var userClub = await _clubrepository.GetByIdAsyncNoTracking(id);
   if (userClub!=null)
   {
    try
    {
     await _photoService.DeletePhotoAsync(userClub.Image);

    }
    catch (Exception ex)
    {
     ModelState.AddModelError("", "Could not delete photo");
     return View(clubVM); 
    }
    var photeResult = await _photoService.AddPhotoAsync(clubVM.Image);
    var club = new Club
    {
     Id = id,
     Title = clubVM.Title,
     Description = clubVM.Description,
     Image = photeResult.Url.ToString(),
     AddressId = clubVM.AddressId,
     AppUserId = clubVM.AppUserId,

     Address = clubVM.Address,
    };

    _clubrepository.Update(club);
    return RedirectToAction("Index");
   }
   else
   {
    return View(clubVM);
   }


  }

  public async Task<IActionResult>Delete (int id)
  {
   var clubDetails = await _clubrepository.GetById(id);

   if (clubDetails==null )
   {
    return View("Error");
   }
   return View(clubDetails);
  }

  [HttpPost,ActionName("Delete")]
  public async Task<IActionResult>DeleteClub(int id)
  {
   var clubDetails = await _clubrepository.GetById(id);
   if (clubDetails == null) return View("Error");

   _clubrepository.Delete(clubDetails);
   return RedirectToAction("Index");

   {

   }
  }

 }
}

