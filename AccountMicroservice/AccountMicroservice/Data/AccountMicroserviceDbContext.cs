using AccountMicroservice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Data
{
    public class AccountMicroserviceDbContext : DbContext 
    {
        public AccountMicroserviceDbContext(DbContextOptions<AccountMicroserviceDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        //public DbSet<Statement> Statements { get; set; }
     

    }
}
