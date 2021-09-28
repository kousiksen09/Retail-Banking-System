using AccountMicroservice.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RulesMicroservice.Controllers;
using RulesMicroservice.Model;
using RulesMicroservice.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesMicroservice.Test
{
    public class Tests
    {
        private Mock<IRuleRepository> _rulesRepoMock;
        private RulesRepository rulesRepo;
        private RulesController rulesController;
        [SetUp]
        public void Setup()
        {
            _rulesRepoMock = new Mock<IRuleRepository>();
            rulesController = new RulesController(_rulesRepoMock.Object);
            rulesRepo = new RulesRepository();
            _rulesRepoMock.Setup(x => x.GetMinBalance(It.IsAny<int>())).ReturnsAsync(1000.00);
        }


        [Test]
        public async Task EvaluateMinBal_ValidInput_int()
        {
            var result =await rulesController.EvaluateMinBalAsync(1, 4000) as OkObjectResult;
         
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task EvaluateMinBal_InValidInput_intAsync()
        {
            var result =await rulesController.EvaluateMinBalAsync(2, 500) as BadRequestObjectResult;

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public void GetAccounts_Exception()
        {
            _rulesRepoMock.Setup(x => x.GetAccounts()).Returns(new List<Account> { });
            Assert.That(() => rulesRepo.GetAccounts(), Throws.Exception);
        }
    }
}