using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unit_Moh.Services.Interfaces;

namespace Unit_Moh.Controllers
{
 [ApiController]
 [Route("api/[controller]")]
 public class FansController : ControllerBase
 {
  private readonly IFanService _fanService;

  public FansController(IFanService fanService)
  {
   _fanService = fanService;
  }

  [HttpGet(Name ="GetFans")]
  public async Task<IActionResult> Get()
  {
   var fans = await _fanService.GetAllFans();

   if (fans.Any())
   return Ok(fans);// http 200 response
  
   return NotFound();
  }
 }
}
