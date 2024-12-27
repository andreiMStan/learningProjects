using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Core;
using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Core.Repositories;

namespace NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Data
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly ApiDbContext _context;
		public IDriverRepository Drivers { get; private set; }

        public UnitOfWork(ApiDbContext context,ILoggerFactory loggerFactory)
        {
			//wired up db context and logger to repository
			//did  connection between interface and implementation
			_context = context;
			var _logger = loggerFactory.CreateLogger("logs");
			Drivers = new DriverRepository(_context, _logger);
        }
        public async Task CompleteAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
