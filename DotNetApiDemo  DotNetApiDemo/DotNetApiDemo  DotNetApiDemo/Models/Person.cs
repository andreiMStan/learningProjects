using System.ComponentModel.DataAnnotations;

namespace DotNetApiDemo__DotNetApiDemo.Models
{
	public class Person
	{

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public  string? Name { get; set; }

		[Required]
		[MaxLength(30)]
		public string? Email { get; set; }
    }
}
