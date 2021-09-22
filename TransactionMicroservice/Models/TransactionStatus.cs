using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    [Keyless]
    public class TransactionStatus
    {
        public string message { get; set; }
        
    }
}
