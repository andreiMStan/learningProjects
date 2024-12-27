using MongoDbDemo.Models;

namespace MongoDbDemo.Services
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAllAsync();
		Task<Product> GetById(string id);
		Task CreateAsync(Product product);
		Task Update(string id, Product product);
		Task Delete(string id);

	}
}