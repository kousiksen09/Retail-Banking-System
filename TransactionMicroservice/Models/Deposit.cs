using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Deposit
    {
        public int AccountId { get; set; }
        public double Amount { get; set; }
    }
}
