using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;


using CustomerMicroService.Controllers;
using CustomerMicroService.Model;
using CustomerMicroService.Repository;

namespace CustomerTest
{
    [TestFixture]
    public class CustomerTest
    {
        private Mock<IRepositoryWrapper> _repo;
        private CustomerController _controller;
        private Customer _customer;



        [SetUp]
        public void setup()
        {
            _repo = new Mock<IRepositoryWrapper>();
            _controller = new CustomerController(_repo.Object);
            _repo.Setup(x => x.Customer.FindByCondition(It.IsAny<int>())).Returns(new Customer());
            _customer = new Customer();
            _repo.Setup(x => x.Customer.Create(_customer)).Returns(true);



        }
        [Test]
        public void GetCustomerDetails_WhenCalledWithNonZeroValues_ReturnsOk()
        {



            var result = _controller.GetCustomerDetails(100) as OkObjectResult;
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }



        [Test]
        public void GetCustomerDetails_WhenCalledWithZeroValues_ReturnsError()
        {
            var result = _controller.GetCustomerDetails(0);
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }
        [Test]
        public void CreateCustomer_WhenCalledWithNonZeroValues_ReturnsOk()
        {




            var result = _controller.CreateCustomer(_customer) as OkObjectResult;
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }



        [Test]
        public void CreateCustomes_WhenCalledWithZeroValues_ReturnsError()
        {
            var result = _controller.CreateCustomer(null) as StatusCodeResult;
            Assert.AreEqual(409, result.StatusCode);
        }
    }
}