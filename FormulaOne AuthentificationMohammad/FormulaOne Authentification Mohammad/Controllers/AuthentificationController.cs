using FormulaOne_Authentification_Mohammad.Configuration;
using FormulaOne_Authentification_Mohammad.Models;
using FormulaOne_Authentification_Mohammad.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FormulaOne_Authentification_Mohammad.Controllers
{
				[Route("api/[controller]")] //api/authentification
				[ApiController]
				public class AuthentificationController : ControllerBase
				{
								//the default user  from identity
								private readonly UserManager<IdentityUser> _userManager;
								private readonly IConfiguration _configuration;
								
								public AuthentificationController(UserManager<IdentityUser> userManager, IConfiguration configuration)
								{
												_userManager = userManager;
												_configuration = configuration;
								}

								[HttpPost]
								[Route("Register")]

								public async Task<IActionResult> Register([FromBody] UserRegistrationDto requestDto)

								{
												//validate incoming request 
												if (ModelState.IsValid)
												{
																//we need to check if the user already exists
																var user_exists = await _userManager.FindByEmailAsync(requestDto.Email);
																if (user_exists != null)
																{
																				return BadRequest(new AuthResults()
																				{
																								Result = false,
																								Errors = new List<string>()
																												{
																																"Email already exists"
																												}
																				});
																}

																//create user

																var newUser = new IdentityUser()
																{
																				Email = requestDto.Email,
																				UserName = requestDto.Email,
																};

																var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);

																if (isCreated.Succeeded)
																{
																				//generate token
																				var token = GenerateJwtToken(newUser);
																				return Ok(new AuthResults()
																				{
																								Result = true,
																								Token = token

																				}) ; 
																}
																return BadRequest(new AuthResults()
																{
																				Errors = new List<string>()
																				{
																								"Server Error"
																				},
																				Result = false
																});


												}
												return BadRequest();
								}

								[Route("Login")]
								[HttpPost]
								public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequest)
								{
												if (ModelState.IsValid)
												{
																//check if user exists
																var existingUser = await _userManager.FindByEmailAsync(loginRequest.Email);

																if (existingUser==null)
																{
																				return BadRequest(new AuthResults()
																				{
																								Errors = new List<string>()
																{
																				"invalid payload"
																},
																								Result = false

																				});
																}

																var isCorrect = await _userManager.CheckPasswordAsync(existingUser, loginRequest.Password);

																if (!isCorrect)
																{
																				return BadRequest(new AuthResults()
																				{
																								Errors = new List<string>()
																{
																				"invalid credentials"
																},
																								Result = false

																				});
																}

																var jwtToken = GenerateJwtToken(existingUser);
																return Ok(new AuthResults()
																{
																				Token = jwtToken,
																				Result = true

																}) ;

												}
												return BadRequest(new AuthResults()
												{
																Errors=new List<string>()
																{
																				"invalid payload"
																},
																Result=false

												});
								}

								private string GenerateJwtToken(IdentityUser user)
								{
												var jwtTokenHandler = new JwtSecurityTokenHandler();

												var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

												//token descriptor 
												var tokenDescriptor = new SecurityTokenDescriptor()
												{
																Subject = new ClaimsIdentity(new[]
																{
																				new Claim("id", user.Id),
																				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
																				new Claim(JwtRegisteredClaimNames.Email, user.Email),
																				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
																				new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
																}),

																Expires=DateTime.Now.AddHours(1),
																SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
												};

												var token = jwtTokenHandler.CreateToken(tokenDescriptor);
												var jwtToken = jwtTokenHandler.WriteToken(token);


												return jwtToken;
								}
				} 
}