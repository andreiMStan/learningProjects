
	namespace NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Core
{
	public interface IUnitOfWork
	{
		IDriverRepository Drivers{get; }
		Task CompleteAsync();
	}


}

//Unity of work is A way to abstract all objects of db
//Every single table has a set of instruction
//mapping the interfaces
