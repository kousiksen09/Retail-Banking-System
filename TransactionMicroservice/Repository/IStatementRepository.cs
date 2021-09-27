//using AccountMicroservice.Model;
//using AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using TransactionMicroservice.Model;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Repository
{
    public interface IStatementRepository
    {

        //public List<Statement> GetAllStatements();

        public Task<List<Statement>> GetStatementAsync(int account_id, DateTime fromdate, DateTime todate);

    }
}
