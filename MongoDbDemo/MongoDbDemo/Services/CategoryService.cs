using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbDemo.Models;
using System.Runtime.InteropServices;

namespace MongoDbDemo.Services
{
	public class CategoryService: ICategoryService

	{
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IOptions<DatabaseSettings> _dbSettings;

        public CategoryService(IOptions<DatabaseSettings> dbSettings)
		{
            
        
			_dbSettings = dbSettings;
			var mongoClient = new MongoClient
				(dbSettings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
			_categoryCollection = mongoDatabase.GetCollection<Category>(dbSettings.Value.CategoriesCollectionName);
		}

		//public async Task<IEnumerable<Category>> GetAllAsync()
		//{
		//	var categories = await _categoryCollection.Find(_ => true).ToListAsync();
		//		return categories;
		//}
		public async Task<IEnumerable<Category>> GetAllAsync()
			=> await _categoryCollection.Find(_=> true).ToListAsync();

		public async Task<Category> GetById(string id)
			=> await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();


		
		public async Task CreateAsync(Category category) =>
			await _categoryCollection.InsertOneAsync(category);

		public async Task Update(string id,Category category) =>
			await _categoryCollection.ReplaceOneAsync(x => x.Id == category.Id, category);

		public async Task Delete(string id) =>
			await _categoryCollection.DeleteOneAsync(x => x.Id == id);


	 
	} 


}
