using NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Models;

namespace NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Core
{
	public interface IDriverRepository:IGenericRepository<Driver>

	{
		Task<Driver?> GetByDriverNumber(int driverNo);

	}
}
