
namespace Guide_to_AutoMapper___Simplify_Your_Object_Mapping_Mohammad.Models.DbSet
{
	public class User
	{
	 public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string PostalCode { get; set; } = string.Empty;
		public string StreetAddress { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }





    }
}
