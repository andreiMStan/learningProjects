using Microsoft.EntityFrameworkCore;
using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Data;
using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Models;

namespace NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Core.Repositories
{
	public class DriverRepository : GenericRepository<Driver>, IDriverRepository
	{
		public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
		{
		}

		public override async Task<IEnumerable<Driver>> All()
		{
			try
			{
				return await _context.Drivers.Where(x => x.Id < 100).ToListAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}
		public override async Task<Driver?> GetById(int id)
		{
			try
			{
				return await _context.Drivers.AsNoTracking()
					.FirstOrDefaultAsync(x => x.Id == id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e) ;
				throw;
			}
		}
		public async Task<Driver?> GetByDriverNumber(int driverNo)
		{
			try
			{
				return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == driverNo);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
