using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbDemo.Models
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

        public string? ProductName { get; set; }

		[BsonRepresentation(BsonType.ObjectId)]
		public string? CategoryId { get; set; }


		//this property will not store in data base if you pass a null value to it, make sure null before passing to db
		[BsonIgnoreIfNull]
		public string? CategoryName { get; set; }
	}

}
