using Microsoft.AspNetCore.Identity;

namespace IdentityTeddy2022.Models
{
				public class AppUser:IdentityUser
				{
        public string NickName { get; set; }
    }
}
