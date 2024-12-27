using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOneApi.Queries
{
	public class GetAllDriversQuery:IRequest<IEnumerable<GetDriverResponse>>
	{

	}
}
