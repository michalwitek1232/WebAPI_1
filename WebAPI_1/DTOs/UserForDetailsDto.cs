using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_1.Models;

namespace WebAPI_1.DTOs
{
    public class UserForDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        //Default Info

        public string Name { get; set; }
        public string Surname { get; set; }

        public int Age { get; set; } //Wiek
        public DateTime Created { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime LastActive { get; set; }

        public string City { get; set; }

        //Zdjęcie

        public ICollection<ProfileImage> ProfileImage { get; set; }

        public string PhotoUrl { get; set; }
    }
}
