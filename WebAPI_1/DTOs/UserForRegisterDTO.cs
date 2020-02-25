using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_1.DTOs
{
    public class UserForRegisterDTO
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
    }

    public class User
    {

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
