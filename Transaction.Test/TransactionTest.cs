using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionMicroservice.Repository;


namespace Transaction.Test
{
    [TestFixture]
    public class TransactionTest
    {
        private Mock<ITransactionRepository> _repo;
    }
}
