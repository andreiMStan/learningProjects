using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingQuiz.Shared.Dtos
{
    public class LoginDto
    {
        [Required,EmailAddress,DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
