using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroService.Model
{
    public class CustomerCreationStatus
    {

        public string Message { get; set; }

      
        public int CustomerId { get; set; }
       
    }
}
