using RunGroupMVC_teddy.Data.Enum;
using RunGroupMVC_teddy.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunGroupMVC_teddy.ViewModels
{
 public class EditClubViewModel
 {
  public int Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
 
  public IFormFile Image { get; set; }
  public string? Url { get; set; }
  public int AddressId{ get; set; }
  public Address Address{ get; set; }
  public string AppUserId { get; set; }

  public ClubCategory ClubCategory { get; set; }
 }
}
