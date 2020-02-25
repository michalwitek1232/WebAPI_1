using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_1.DTOs
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "Hasło musi się składać z 6 do 24 znaków")]
        public string Password { get; set; }
    }

}
