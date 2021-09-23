using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    [Keyless]
    public class TransactionStatus
    {
        
        public int Id { get; set; }
        public string message { get; set; }

    }
}
