using CustomerMicroService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroService
{
    public class CustomeContext:DbContext
    {
        public CustomeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
       
    }
}
