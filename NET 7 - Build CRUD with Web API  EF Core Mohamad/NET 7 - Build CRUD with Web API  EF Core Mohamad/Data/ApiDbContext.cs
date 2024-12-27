using Microsoft.EntityFrameworkCore;
using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Models;

namespace NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Data
{
	public class ApiDbContext:DbContext

	{
        public DbSet<Driver> Drivers { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }
    }
}
