using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_1.Models;

namespace WebAPI_1.Data
{
    public interface IAuthRepository
    {
        Task<User> Login(string Username, string password);

        Task<User> Register(User user, string password);

        Task<bool> UserExist(string Username);

    }
}
