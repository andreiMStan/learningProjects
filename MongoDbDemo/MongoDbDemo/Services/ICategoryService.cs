using MongoDbDemo.Models;

namespace MongoDbDemo.Services
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetAllAsync();
		Task<Category> GetById(string id);
		Task CreateAsync(Category category);
		Task Update(string id, Category category);
		Task Delete(string id);
	} 
}