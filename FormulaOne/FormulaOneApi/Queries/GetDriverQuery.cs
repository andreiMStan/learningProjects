using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOneApi.Queries
{
	public class GetDriverQuery:IRequest<GetDriverResponse>
	{
		public Guid DriverId{get;}
        public GetDriverQuery(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}
