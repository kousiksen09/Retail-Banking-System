using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.Models;

namespace UserMicroService.DBContext
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<UserCred> UserCreds { get; set; }
    }
}
