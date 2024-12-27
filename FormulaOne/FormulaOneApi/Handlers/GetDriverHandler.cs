using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using FormulaOneApi.Queries;
using MediatR;

namespace FormulaOneApi.Handlers
{
	public class GetDriverHandler : IRequestHandler<GetDriverQuery, GetDriverResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetDriverHandler(
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;


		}

		public async Task<GetDriverResponse> Handle(GetDriverQuery request, CancellationToken cancellationToken)
		{
			var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

			return  driver==null ? null :_mapper.Map<GetDriverResponse>(driver);
		}
	}
}
