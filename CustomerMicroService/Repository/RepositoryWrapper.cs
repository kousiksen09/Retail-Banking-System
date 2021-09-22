using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroService.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CustomeContext _customerContext;
        private ICustomerRepository _customer;
        public RepositoryWrapper(CustomeContext customeContext)
        {
            _customerContext = customeContext;
        }
        public ICustomerRepository Customer
        {
            get
            {
                if(_customer==null)
                {
                    _customer = new CustomerRepository(_customerContext);
                }
                return _customer;
            }
        }

        public void Save()
        {
            _customerContext.SaveChanges();
        }
    }
}
