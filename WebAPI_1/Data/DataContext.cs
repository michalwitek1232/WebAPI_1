using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_1.Models;

namespace WebAPI_1.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { } //wywołuje konst bazowy i przekazuje opcje

        public DbSet<Users> Users { get ; set; }

        public DbSet<User> User { get; set; }
    }
}
