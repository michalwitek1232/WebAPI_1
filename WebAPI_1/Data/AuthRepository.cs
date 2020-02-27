using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_1.Models;

namespace WebAPI_1.Data
{
    public static class Helpers
    {
        public static void CreatePasswordHashSalt(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hamac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hamac.Key;
                PasswordHash = hamac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
    public class AuthRepository : IAuthRepository
    {
        public readonly DataContext _context;


        #region MetodyPubliczne
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string Username, string Password)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Username == Username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPassword(Password, user.PasswordHash, user.PasswordSalt)) { return null; }
            else
            {
                return user;
            }
        }



        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            Helpers.CreatePasswordHashSalt(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExist(string Username)
        {
            if (await _context.User.AnyAsync(x => x.Username == Username))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
       

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hamac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hamac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i<computedHash.Length;i++ )
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

    }
}
