namespace MongoDbDemo.Models
{
	public class DatabaseSettings
	{
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? CategoriesCollectionName { get; set; }
        public string? ProductCollectionName { get; set; }

    }
}
