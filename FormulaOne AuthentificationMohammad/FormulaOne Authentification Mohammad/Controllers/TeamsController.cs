using FormulaOne_Authentification_Mohammad.Data;
using FormulaOne_Authentification_Mohammad.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne_Authentification_Mohammad.Controllers
{
				[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
				[Route("api/[controller]")]
				[ApiController]
				public class TeamsController : ControllerBase

				{
								private readonly AppDbContext _ctx;
								public TeamsController(AppDbContext ctx)
								{
												_ctx = ctx;
								}

								[HttpGet]
								//					[Route("GetBestTeam")]
								public async Task<IActionResult> Get()
								{
												var teams = await _ctx.Teams.ToListAsync();

												return Ok(teams);
								}


								[HttpGet("{id:int}")]
								public async Task<IActionResult> Get(int id)
								{
												var team = await _ctx.Teams.FirstOrDefaultAsync(x => x.Id == id);
												if (team == null)
												{
																return BadRequest("invalid id");
												}

												return Ok(team);
								}

								[HttpPost]
								public async Task<IActionResult> Post(Team team)
								{
												await _ctx.Teams.AddAsync(team);
												if (team == null)
												{
																return BadRequest("invalid id");
												}
												_ctx.SaveChangesAsync();

												return CreatedAtAction("Get", team.Id, team);

												//action name =get
												//the route value=team.id
												//the object valu=team

												//1.we need to receive status code of 201, stating object has been added
												//2.url how we can get the idem 
												//3. the body of the object that we added
								}

								[HttpPatch("{id:int}")]
								public async Task<IActionResult> Patch(int id, string country)
								{
												var team = await _ctx.Teams.FirstOrDefaultAsync(x => x.Id == id);

												if (team == null)
												{
																return BadRequest("invalid id");
												}
												team.Country = country;
												_ctx.SaveChangesAsync();
												return NoContent();
								}

								[HttpDelete("{id:int}")]

								public async Task<IActionResult> Remove(int id)
								{
												var team = await _ctx.Teams.FirstOrDefaultAsync(x => x.Id == id);
												if (team == null)
												{
																return BadRequest("invalid id");
												}
												_ctx.Teams.Remove(team);
												_ctx.SaveChangesAsync();

												return NoContent();
								}

				}
}
