using CustomerMicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerMicroService.Repository
{
    public interface IRepository<T>
    {
        T FindByCondition(int id);
        bool Create(T entity);
    }
}
