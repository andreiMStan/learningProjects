using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Core;
using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Data;
using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Models;

namespace NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class DriversController : ControllerBase
	{

		private readonly IUnitOfWork _unitOfWork;

        public DriversController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        //private readonly ApiDbContext _context;
        //      public DriversController(ApiDbContext context)
        //      {
        //	_context = context;
        //      }
        //      //private static List<Driver> _drivers = new()
        //{
        //	new Driver()
        //	{
        //		Id=1,
        //		Name="Louise Ha",
        //		DriverNumber=1,
        //		Team= "mercedes"

        //	},
        //	new Driver()
        //	{
        //		Id=2,
        //		Name="aassd Ha",
        //		DriverNumber=2,
        //		Team= "asdasad"

        //	},
        //	new Driver()
        //	{
        //		Id=3,
        //		Name="bbbbb Ha",
        //		DriverNumber=2,
        //		Team= "bbbb"

        //	}

        //};


        [HttpGet]
		//connectint to Db context
		//Telling you need to go to Drivers Table 
		//Get me everything from there in a list
		public async Task<IActionResult> Get()
		{
			return Ok(await _unitOfWork.Drivers.All());
			//return Ok(await _context.Drivers.ToListAsync());
		}


		[HttpGet]
		[Route("GetById")]
		public async Task<IActionResult> Get(int id)
		{
			var driver = await _unitOfWork.Drivers.GetById(id);
			//var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
			if (driver==null)
			{
				return NotFound();
			}
			return Ok(driver);
		}

		[HttpPost]
		[Route("AddDriver")]

		public async Task<IActionResult> Post(Driver driver)
		{

			await _unitOfWork.Drivers.Add(driver);
			await _unitOfWork.CompleteAsync();
			//_context.Drivers.Add(driver);
		//	await _context.SaveChangesAsync();
			return Created("/driver{id}", driver);
		}

		[HttpDelete]
		[Route("DeleteDriver")]

		public async Task<IActionResult> DeleteDriver(int id)
		{
			var driver = await _unitOfWork.Drivers.GetById(id);
			//var driver = _context.Drivers.FirstOrDefault(x => x.Id == id);

			if (driver==null)
			{
				return NotFound();
			}

		 await  _unitOfWork.Drivers.Delete(driver);
			await _unitOfWork.CompleteAsync();
			//_context.Drivers.Remove(driver);
			//await _context.SaveChangesAsync();
			return NoContent(); 


		}

		[HttpPatch]
		[Route("UpdateDriver")]
		public async Task<IActionResult> UpdateDriver(Driver driver)
		{
			var existDriver = _unitOfWork.Drivers.GetById(driver.Id);
			//var existDriver = _context.Drivers.FirstOrDefault(x => x.Id == driver.Id);

				if (existDriver == null) return NotFound();

			//existDriver.Name = driver.Name;
			//existDriver.Name = driver.Team;
			//existDriver.DriverNumber = driver.DriverNumber;
			//await _context.SaveChangesAsync();

			await _unitOfWork.Drivers.Update(driver);
			await _unitOfWork.CompleteAsync();
			return NoContent();

										
		}
	}
}
