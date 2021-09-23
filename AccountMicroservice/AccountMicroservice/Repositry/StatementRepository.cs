using AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repositry
{
    public class StatementRepository : IStatementRepository
    {
        List<Statement> statements = new List<Statement>() { };

        private readonly IAccountRepository accountrepo;
        public StatementRepository(IAccountRepository _accountrepo)
        {
            accountrepo = _accountrepo;
        }

        public List<Statement> GetAllStatements()
        {
            throw new NotImplementedException();
        }

        public Statement GetStatement(int account_id, DateTime fromdate, DateTime todate)
        {
            var account = accountrepo.GetPerticularAccount(account_id);
            statements.Add(new Statement { StatementId = 1, AccountId = account_id, Narration = $"{account_id} Account's statement", refNo = "ref01",ValueDate=fromdate, date = todate, Deposit = 2000, Withdrawl = 1000, ClosingBalance=1000 });
            var statement = statements.Find(s => s.AccountId == account_id);
            return statement;
        }
    }
}
