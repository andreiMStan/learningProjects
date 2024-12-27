using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOneApi.Commands
//converting the post end point into command
{
	public class CreateDriverInfoRequest:IRequest<GetDriverResponse>
	{
		public  CreateDriverRequest DriverRequest { get; }
        public CreateDriverInfoRequest(CreateDriverRequest driverRequest)
        {
			DriverRequest = driverRequest;
		}


    }
}
