using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOneApi.Commands;
using MediatR;

namespace FormulaOneApi.Handlers
{
	public class UpdateDriverInfoHandler : IRequestHandler<UpdateDriverInfoRequest, bool>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateDriverInfoHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;


		}
		public async Task<bool> Handle(UpdateDriverInfoRequest request, CancellationToken cancellationToken)
		{
			var result = _mapper.Map<Driver>(request.Driver);
			await _unitOfWork.Drivers.Update(result);
			await _unitOfWork.CompleteAsync();
			return true;
		}
	}
}
