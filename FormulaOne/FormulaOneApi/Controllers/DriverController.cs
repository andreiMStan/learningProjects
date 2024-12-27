using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using FormulaOneApi.Commands;
using FormulaOneApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace FormulaOneApi.Controllers
{

	public class DriverController : BaseController
	{
		//private readonly IMediator _mediator;

		public DriverController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
		{
		}

		[HttpGet]
		[Route("{driverId:guid}")]
		public async Task<IActionResult> GetDriver(Guid driverId)
		{
			//var driver = await _unitOfWork.Drivers.GetById(driverId);
			//if (driver == null )
			//	return NotFound();

			//var result = _mapper.Map<GetDriverResponse>(driver);
			var query = new GetDriverQuery(driverId);
			var result = await _mediator.Send(query);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDrivers()

		{//specifying the query that i have for this endpoint
			var query = new GetAllDriversQuery();
			var result = await _mediator.Send(query);
			return Ok(result);

		}

		[HttpPost("")]
		public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			//var result = _mapper.Map<Driver>(driver);
			//await _unitOfWork.Drivers.Add(result);
			//await _unitOfWork.CompleteAsync();
			//return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);

			// with mediator
			var command = new CreateDriverInfoRequest(driver);
			var result = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);

		}

		[HttpPut("")]
		public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			//var result = _mapper.Map<Driver>(driver);
			//await _unitOfWork.Drivers.Update(result);
			//await _unitOfWork.CompleteAsync();
			var command = new UpdateDriverInfoRequest(driver);
			var result = await _mediator.Send(command);
			return result ? NoContent():BadRequest();
		}
	
	

		[HttpDelete]
		[Route("{driverId:guid}")]

		public async Task<IActionResult>DeleteDriver(Guid driverId)
		{
			//var driver = await _unitOfWork.Drivers.GetById(driverId);
			//if (driver==null)
			//{
			//	return NoContent();
			//}
			//await _unitOfWork.Drivers.Delete(driverId);
			//await _unitOfWork.CompleteAsync();

			var command = new DeleteDriverInfoRequest(driverId);
			var result = await _mediator.Send(command);
			
			return result ? NoContent(): BadRequest();
		}
	}
}
