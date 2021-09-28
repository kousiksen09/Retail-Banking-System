using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace TransactionMicroservice
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
        {

        }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        public DbSet<Statement> Statements { get; set; }

      

    }
}
