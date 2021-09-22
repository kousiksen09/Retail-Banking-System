using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroService.Repository
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        void Save();
    }
}
