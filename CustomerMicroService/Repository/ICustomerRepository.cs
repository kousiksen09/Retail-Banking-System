using CustomerMicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroService.Repository
{
    public interface ICustomerRepository:IRepository<Customer>
    {
    }
}
