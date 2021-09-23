using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Model
{
    public class TransactionStatus
    {
        public string Message { get; set; }
        public double source_balance { get; set; }
        public double destination_balance { get; set; }
    }
}
