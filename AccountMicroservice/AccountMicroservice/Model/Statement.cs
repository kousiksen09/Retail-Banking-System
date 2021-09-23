using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Model
{
    public class Statement
    {
        [Key]
        public int StatementId { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public DateTime date { get; set; }
        public string Narration { get; set; }
        public string refNo { get; set; }
        public DateTime ValueDate { get; set; }
        public double Withdrawl { get; set; }
        public double Deposit { get; set; }
        public double ClosingBalance { get; set; }
    }
}
