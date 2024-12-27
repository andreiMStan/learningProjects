 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RunGroupMVC_teddy.Data.Enum;

namespace RunGroupMVC_teddy.Models
{
 public class Race

 {
  [Key]
  public int Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public string Image { get; set; }

  [ForeignKey("Address")]
  public int AddressId { get; set; }
  public Address Address { get; set; }
  public RaceCategory RaceCategory { get; set; }

  [ForeignKey("AppUser")]
  public string? AppUserId { get; set; }

  public AppUser? AppUser { get; set; }


        //Abstracting away the complexity of the app by modeling the database 
        //separating the bussiness logic in different tables 
 }
}
