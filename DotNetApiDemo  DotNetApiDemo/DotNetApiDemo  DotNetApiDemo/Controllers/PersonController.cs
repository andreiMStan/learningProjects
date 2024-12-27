using DotNetApiDemo__DotNetApiDemo.Models;
using DotNetApiDemo__DotNetApiDemo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetApiDemo__DotNetApiDemo.Controllers
{
	[Route("api/people")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IPersonRepository _personRepo;

		public PersonController(IPersonRepository personRepo)
		{
			_personRepo = personRepo;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllPeople()
		{
			try
			{
				var people = await _personRepo.GetAllPeople();
				return Ok(people);//status 200 and people array in resp body
			}
			catch (Exception ex)
			{
				//log exceptions here
				return StatusCode
					(StatusCodes.Status500InternalServerError,
					new ResponseModel { StatusCode = 500, Message =
										"Something went wrong" });
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreatePerson(Person person)
		{
			//check the validation
			if (!ModelState.IsValid)
			{
				//validation failed
				//return BadRequest(new ResponseModel { StatusCode = 400, Message = "Please pass valid data and fill all required field" });
				//return 402
				return UnprocessableEntity(ModelState);
			}
			try
			{

				await _personRepo.AddPerson(person);
				return CreatedAtAction(nameof(CreatePerson), person);

			}
			catch (Exception ex)
			{
				//log exceptions here
				return StatusCode
					(StatusCodes.Status500InternalServerError,
					new ResponseModel
					{
						StatusCode = 500,
						Message =
										"Something went wrong"
					});
			}
		}

		[HttpPut]
		public async Task<IActionResult> UpdatePerson(Person person)
		{
			//check the validation
			if (!ModelState.IsValid)
			{
				//validation failed
				//return BadRequest(new ResponseModel { StatusCode = 400, Message = "Please pass valid data and fill all required field" });
				return UnprocessableEntity(ModelState);

			}
			try
			{

				var existPerson = await _personRepo.GetPersonById(person.Id);
				if (existPerson == null)
				{
					return NotFound(new ResponseModel { StatusCode = 404, Message = "No resource found" });

				}
				await _personRepo.UpdatePerson(existPerson);
				return Ok(person);

			}
			catch (Exception ex)
			{
				//log exceptions here
				return StatusCode
					(StatusCodes.Status500InternalServerError,
					new ResponseModel
					{
						StatusCode = 500,
						Message =
										"Something went wrong"
					});
			}
		}

		[HttpGet("id")]
		public async Task<IActionResult> GetPerson(int id)
		{
			try
			{
				var person=await _personRepo.GetPersonById(id);
				if (person==null)
				{
					return NotFound(new ResponseModel { StatusCode = 404, Message = "No resource found" });

				}

				return Ok(person);
			}
			catch (Exception ex)
			{
				//log exceptions here
				return StatusCode
					(StatusCodes.Status500InternalServerError,
					new ResponseModel
					{
						StatusCode = 500,
						Message =
										"Something went wrong"
					});
			}
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePerson(int id)
		{
			try
			{
				var person = await _personRepo.GetPersonById(id);
				if (person == null)
				{
					return NotFound(new ResponseModel { StatusCode = 404, Message="Resource not found " }) ;
				}
				await _personRepo.DeletePerson(id);
				return Ok(new ResponseModel { StatusCode = 200,Message="Deleted Succesfully" }) ;
			}
			catch (Exception ex)
			{
				//log exceptions here
				return StatusCode
					(StatusCodes.Status500InternalServerError,
					new ResponseModel
					{
						StatusCode = 500,
						Message =
										"Something went wrong"
					});
			}
		}
	}
}
