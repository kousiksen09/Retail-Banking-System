using CustomerMicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroService.Repository
{
    public class CustomerRepository:RepositoryBase<Customer>,ICustomerRepository
    {
        public CustomerRepository(CustomeContext customeContext):base(customeContext)
        {

        }
    }
}
