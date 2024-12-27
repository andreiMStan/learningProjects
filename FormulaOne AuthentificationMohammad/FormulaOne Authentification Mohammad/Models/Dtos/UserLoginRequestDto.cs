using System.ComponentModel.DataAnnotations;

namespace FormulaOne_Authentification_Mohammad.Models.Dtos
{
				public class UserLoginRequestDto
				{
        [Required]
        public string Email { get; set; }
								
								[Required]

								public string Password { get; set; }

    }
}
