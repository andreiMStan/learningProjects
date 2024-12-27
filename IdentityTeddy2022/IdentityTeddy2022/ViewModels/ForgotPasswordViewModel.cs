using System.ComponentModel.DataAnnotations;

namespace IdentityTeddy2022.ViewModels
{
 public class ForgotPasswordViewModel
 {

  [Required]
  [EmailAddress]
  public string Email { get; set; }
 }
 }
