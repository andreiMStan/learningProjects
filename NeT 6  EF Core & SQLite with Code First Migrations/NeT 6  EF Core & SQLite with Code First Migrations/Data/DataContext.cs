using Microsoft.EntityFrameworkCore;

namespace NeT_6__EF_Core___SQLite_with_Code_First_Migrations.Data
{
	public class DataContext : DbContext

	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<RpgCharacter> RpgCharacters => Set<RpgCharacter>();
	}
}
