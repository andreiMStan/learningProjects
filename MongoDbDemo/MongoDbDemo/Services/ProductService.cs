using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbDemo.Models;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace MongoDbDemo.Services
{
	public class ProductService: IProductService

	{
		private readonly IMongoCollection<Product> _productCollection;
		private readonly IOptions<DatabaseSettings> _dbSettings;

        public ProductService(IOptions<DatabaseSettings> dbSettings)
		{
            
        
			_dbSettings = dbSettings;
			var mongoClient = new MongoClient
				(dbSettings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
			_productCollection = mongoDatabase.GetCollection<Product>(dbSettings.Value.ProductCollectionName);
		}

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			//define the pipeline for aggregation

			var pipeline = new BsonDocument[]
			{
				new BsonDocument("$lookup",new BsonDocument
				{
					{"from","CategoryCollection" }
					,{"localField","CategoryId"},
					{"foreignField","_id" },
					{"as","product_category"}
				})
				,
				new BsonDocument("$unwind","$product_category"),
				new BsonDocument("$project",new BsonDocument
				{
					{"_id",1 },
					{ "CategoryId",1},
					{"ProductName",1 },
					{"CategoryName","$product_category.CategoryName" }
				})
			};
			var results=await _productCollection.Aggregate<Product>(pipeline).ToListAsync();
			return results;
		}
		//public async Task<IEnumerable<Category>> GetAllAsync()
		//{
		//	var categories = await _categoryCollection.Find(_ => true).ToListAsync();
		//		return categories;
		//}
		//public async Task<IEnumerable<Product>> GetAllAsync()
		//	=> await _productCollection.Find(_=> true).ToListAsync();

		public async Task<Product> GetById(string id)
			=> await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(Product product) =>
			await _productCollection.InsertOneAsync(product);

		public async Task Update(string id, Product product) =>
			await _productCollection.ReplaceOneAsync(x => x.Id == product.Id, product);

		public async Task Delete(string id) =>
			await _productCollection.DeleteOneAsync(x => x.Id == id);


	 
	} 


}
