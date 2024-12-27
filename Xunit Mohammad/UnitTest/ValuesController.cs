using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
 [ApiController]
 [Route("api/[controller]")]
 public class FansController : ControllerBase
 {
  [HttpGet(Name ="GetFans")]
 
  public async Task<IActionResult> Get()
  {
   return Ok("fans");
    }

   }

}
