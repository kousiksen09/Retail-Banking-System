using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerMicroService.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly CustomeContext _customerContext;
       
        public RepositoryBase(CustomeContext customeContext)
        {
            _customerContext = customeContext;
        }
        public bool Create(T entity)
        {
           
                _customerContext.Set<T>().Add(entity);
              
                return true;
           
            
        }

        public T FindByCondition(int id)
        {
           return _customerContext.Set<T>().Find(id);
        }
    }
}
