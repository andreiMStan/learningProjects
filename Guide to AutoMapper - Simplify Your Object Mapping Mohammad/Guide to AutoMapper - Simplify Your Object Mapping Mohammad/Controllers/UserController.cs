using AutoMapper;
using Guide_to_AutoMapper___Simplify_Your_Object_Mapping_Mohammad.Models.DbSet;
using Guide_to_AutoMapper___Simplify_Your_Object_Mapping_Mohammad.Models.Dtos.Repositories;
using Guide_to_AutoMapper___Simplify_Your_Object_Mapping_Mohammad.Models.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Guide_to_AutoMapper___Simplify_Your_Object_Mapping_Mohammad.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ILogger<UserController> _logger;

		public UserController(ILogger<UserController> logger, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;
		}


		[HttpGet]
		public IActionResult GetUser()
		{
			var _user = new User()
			{
				Email = "sadsada@.com",
				FirstName = "Andsds",
				LastName = "asdasd",
				Id = Guid.NewGuid(),
				PostalCode = "2222",
				StreetAddress = "strreet"

			};
			var returnUser = _mapper.Map<GetUserResponse>(_user);
			return Ok(returnUser );
		}
		[HttpPost]

		public IActionResult CreateUser([FromBody]CreateUserRequest user)
		{

			var newUser = _mapper.Map<User>(user) ;
			return Ok(newUser);
		}




	}
}