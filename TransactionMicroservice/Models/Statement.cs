using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Statement
    {
        [Key]
        public int StatementId { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        //public DateTime FromDate { get; set; }
        public string Narration { get; set; }
        public string RefNo { get; set; }
        //public DateTime ToDate { get; set; }
        //public double Withdrawl { get; set; }
        //public double Deposit { get; set; }
        public double ClosingBalance { get; set; }

        public double Amount { get; set; }
    }
}
