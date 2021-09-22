using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class TransactionHistory
    {
        [Key]
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public double TransactionAmount { get; set; }
        public string message { get; set; }
        public double source_balance { get; set; }
        public double destination_balance { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
