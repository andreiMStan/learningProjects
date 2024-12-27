namespace NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Core
{

	//
	public interface IGenericRepository<T> where T:class
	{
		Task<IEnumerable<T>> All();
		Task<T?> GetById(int id);

		Task<bool> Add(T entity);

		Task<bool> Update(T entity);

		Task<bool> Delete(T entity);

	}

}
