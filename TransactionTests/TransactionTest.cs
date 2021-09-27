using AccountMicroservice.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionMicroservice.Controllers;
using TransactionMicroservice.Models;
using TransactionMicroservice.Repository;

namespace TransactionTests
{
    [TestFixture]
    public class TransactionTest
    {
        private Mock<ITransactionRepository> _repo;
        private TransactionController _controller;

        [SetUp]
        public void setup()
        {
            _repo = new Mock<ITransactionRepository>();
            _controller = new TransactionController(_repo.Object);
        }


        //GetTransactionHistory Testing...
        [Test]
        public void getTransactions_WhenCalledNonZeroValues_ReturnsOk()
        {
            _repo.Setup(x => x.GetTransactionHistory(It.IsAny<int>())).Returns(new List<TransactionHistory> { new TransactionHistory() });

            var result = _controller.getTransactions(1);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void getTransactions_WhenCalledWithZero_ReturnsNotFound()
        {
            var result = _controller.getTransactions(0);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }


        //Deposit Testing...
        [Test]
        public async Task deposit_WhenCalledWithNonZeroValues_ReturnsOk()
        {

            _repo.Setup(x => x.GetDetailsAsync(It.IsAny<int>())).ReturnsAsync(new Account());
            _repo.Setup(x => x.DepositAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new TransactionStatus());

            var result = await _controller.Deposit(1,1000) as OkObjectResult; ;

            Assert.That(result,Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task deposit_WhenCalledWithZeroValues_ReturnsNotFound()
        {
            var result = await _controller.Deposit(0,0);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }


        //Withdraw Testing...
        [Test]
        public async Task withdraw_WhenCalledWithNonZeroValues_ReturnsOkAsync()
        {
            _repo.Setup(repo => repo.GetDetailsAsync(It.IsAny<int>())).ReturnsAsync(new Account());
            _repo.Setup(repo => repo.WithdrawAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new TransactionStatus());

            var result = await _controller.WithdrawAsync(1,500);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            
        }

        [Test]
        public async Task withdraw_WhenCalledWithZeroValues_ReturnsNotFound()
        {

            var result = await _controller.WithdrawAsync(0,0);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        //Transfer Testing...
        [Test]
        public async Task Transfer_WhenCalledWithNonbZeroValues_ReturnsOk()
        {
            _repo.Setup(repo => repo.GetDetailsAsync(It.IsAny<int>())).ReturnsAsync(new Account());
            _repo.Setup(repo => repo.DepositAsync(It.IsAny<int>(), It.IsAny<double>())).ReturnsAsync(new TransactionStatus());
            _repo.Setup(repo => repo.WithdrawAsync(It.IsAny<int>(), It.IsAny<double>())).ReturnsAsync(new TransactionStatus());
            _repo.Setup(repo => repo.TransferAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>())).ReturnsAsync(new TransactionStatus());

            var result = await _controller.TransferAsync(1,2,1000) as OkObjectResult;

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Transfer_WhenCalledWithZeroValues_ReturnsNotFoundOk()
        {
            var result = await _controller.TransferAsync(0,0,0);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

    }
}
