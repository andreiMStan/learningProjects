using FormulaOne_Authentification_Mohammad.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne_Authentification_Mohammad.Data
{
				public class AppDbContext:IdentityDbContext
				{
								public DbSet<Team> Teams { get; set; }
								public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
								}			
				}
}
