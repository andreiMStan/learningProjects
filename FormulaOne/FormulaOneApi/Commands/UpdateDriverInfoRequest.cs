using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOneApi.Commands
{
	public class UpdateDriverInfoRequest : IRequest<bool>

	{
		public UpdateDriverRequest Driver { get; }

        public UpdateDriverInfoRequest(UpdateDriverRequest driver)
        {
			Driver = driver;
		}
    }
}
