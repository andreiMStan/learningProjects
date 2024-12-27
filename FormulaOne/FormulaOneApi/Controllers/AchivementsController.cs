using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace FormulaOneApi.Controllers
{

	public class AchivementsController : BaseController
	{ 
		public AchivementsController
			(IUnitOfWork unitOfWork,
			IMapper mapper,
			IMediator mediator) : base  (unitOfWork, mapper,mediator )
		{
		}

		[HttpGet]
		[Route("/{driverId:guid}")]
		public async Task<IActionResult> GetDriverAchivements(Guid driverId)
		{

		
           var driverAchivements = await _unitOfWork.Achivements.GetDriverAchivementAsync(driverId);

			if (driverAchivements == null)
				return NotFound("achivement not found");

			var result = _mapper.Map<DriverAchivementResponse>(driverAchivements);
		return Ok(result);
		}
		
		
	
		

		[HttpPost]
		[Route("/")]
		public async Task<IActionResult> AddAchivement([FromBody] CreateDriverAchivementRequest achivement)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var result = _mapper.Map<Achivement>(achivement);
			await _unitOfWork.Achivements.Add(result);
			await _unitOfWork.CompleteAsync();
			return CreatedAtAction(nameof(GetDriverAchivements), new { driverId = result.DriverId }, result);
		}

		[HttpPut("")]
		

		public async Task<IActionResult> UpdateAchivement([FromBody] UpdateDriverAchivementsRequest achivement)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var result = _mapper.Map<Achivement>(achivement);

			await _unitOfWork.Achivements.Update(result);
			await _unitOfWork.CompleteAsync();
			return NoContent();
		}
	}
}
