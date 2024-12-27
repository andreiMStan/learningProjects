using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NeT_6__EF_Core___SQLite_with_Code_First_Migrations.Data;

namespace NeT_6__EF_Core___SQLite_with_Code_First_Migrations.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RpgCharacterController : ControllerBase
	{
		private readonly DataContext _context;
		public RpgCharacterController(DataContext context)

		{
			_context = context;
		}

		[HttpPost]
	

		public async Task<ActionResult<List<RpgCharacter>>> AddCharacter(RpgCharacter character)
		{
			_context.RpgCharacters.Add(character);
			await _context.SaveChangesAsync();
			return Ok(await _context.RpgCharacters.ToListAsync());
		}

		[HttpGet]
		public async Task<ActionResult<List<RpgCharacter>>> GetAllCharacters()
		{ return Ok(await _context.RpgCharacters.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<RpgCharacter>>>GetCharacter(int id)
		{
			var character = await _context.RpgCharacters.FindAsync(id);
			if (character == null)
				return NotFound();
			return Ok(character);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<List<RpgCharacter>>> DeleteCharacter(int id)
		{
			var character = await _context.RpgCharacters.FindAsync(id);
			if (character == null)
				return NotFound();
			_context.RpgCharacters.Remove(character); 
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
