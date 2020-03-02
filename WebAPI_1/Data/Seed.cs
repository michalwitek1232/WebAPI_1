using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_1.Data;
using WebAPI_1.Models;

namespace WebAPI_1.Models
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            this._context = context;
        }

        public void SeedUsers()
        {
            var userData = File.ReadAllText("./Data/UserSeedData.json");
            var usersSerialized = JsonConvert.DeserializeObject<List < User >> (userData);

            foreach(var user in usersSerialized)
            {
                byte[] passwordHash, passwordSalt;
                Helpers.CreatePasswordHashSalt("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.User.Add(user);
            }

            _context.SaveChanges();
        }

        public void SeedEvents()
        {
            var eventData = File.ReadAllText("./Data/EventSeedData.json");
            var eventsSerialized = JsonConvert.DeserializeObject<List <EventModel> >(eventData);

            foreach (var events in eventsSerialized )
            {
                _context.Add(events);
            }

            _context.SaveChanges();
        }
    }
}
