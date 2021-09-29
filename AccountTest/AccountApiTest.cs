using AccountMicroservice.Controllers;
using AccountMicroservice.Data;
using AccountMicroservice.Model;
using AccountMicroservice.Repositry;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccountTest
{
    [TestFixture]
    public class AccountApiTest
    {

        private Mock<IAccountRepository> _acpr;
        private AccountController _act;
        private AccountMicroserviceDbContext _acm;

        [SetUp]
        public void SetUp()
        {
            _acpr = new Mock<IAccountRepository>();
            _act = new AccountController(_acpr.Object,_acm);

        }

        [Test]
        public void CreateAccount_WhenCalledZeroValues_ReturnsBadRequest()
        {
            var result = _act.CreateAccount(0) as BadRequestResult;

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public void CreateAccount_WhenCalledValidNonZeroValue_ReturnsOKRequest()
        {
            _acpr.Setup(a => a.CreateAccount(It.IsAny<int>())).Returns(true);


            var result = _act.CreateAccount(2) as OkObjectResult;


            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void GetCustomerAccounts_whenCalledZero_RetursBadRequest()
        {
            var result = _act.GetCustomerAccounts(0) as BadRequestResult;


            Assert.That(result, Is.InstanceOf<BadRequestResult>());

        }

        [Test]
        public void GetCustomerAccounts_whenCalledNonZero_RetursOKRequest()
        {
            _acpr.Setup(a => a.GetCutomerAccounts(It.IsAny<int>())).Returns(new List<Account>());


            var result = _act.GetCustomerAccounts(2) as OkObjectResult;


            Assert.That(result, Is.InstanceOf<OkObjectResult>());

        }




        [Test]
        public void GetAccounts_whenCalledNonZero_RetursOKRequest()
        {
            _acpr.Setup(a => a.GetParticularAccount(It.IsAny<int>())).Returns(new Account());

            //_acpr.Setup(a=> a.CreateAccount(It.IsAny<int>()).ReturnsAsync(new Account()));
            var result = _act.GetAccount(201340) as OkObjectResult;


            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }





    }
}
