using AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repositry
{
    public interface IStatementRepository
    {

        public List<Statement> GetAllStatements();

        public Statement GetStatement(int account_id, DateTime fromdate, DateTime todate);

    }
}
