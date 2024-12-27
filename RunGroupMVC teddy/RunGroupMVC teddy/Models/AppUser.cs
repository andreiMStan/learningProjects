using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunGroupMVC_teddy.Models
{
 public class AppUser:IdentityUser
 {

        public int? Pace { get; set; }
        public int? Milage  { get; set; }
   // if you want to create multiple images you can create a photo model another class
        public string?ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address  { get; set; }

        public ICollection<Club> Clubs { get; set; }
        public ICollection<Race> Races { get; set; }
    }

}
