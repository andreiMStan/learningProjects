using PokemonTeddy.Models;

namespace PokemonTeddy.Interfaces
{
				public interface ICategoryRepository
				{
								//GetRequests
								ICollection<Category> GetCategories();
								Category GetCategory(int id);

								ICollection<Pokemon> GetPokemonByCategory(int categoryId);

								bool CategoryExists(int id);

								//CreateRequests
								bool CreateCategory(Category category);
								bool UpdateCategory(Category category);
								bool DeleteCategory(Category category);
								bool Save();

				}
}
