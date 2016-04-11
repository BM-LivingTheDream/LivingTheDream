using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FabrikamFiber.Web.Controllers;
using Moq;
using FabrikamFiber.DAL.Models;
using FabrikamFiber.DAL.Data;
using System.Web.Mvc;

namespace FabrikamFiber.Web.UnitTests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        Mock<ICustomerRepository> mockCustomerRepo;
        CustomersController controller;

        [TestInitialize()]
        public void SetupController()
        {
            mockCustomerRepo = new Mock<ICustomerRepository>();
            controller = new CustomersController(mockCustomerRepo.Object as ICustomerRepository);
        }

        [TestMethod()]
        public void CreateInsertsCustomerAndSaves()
        {
            controller.Create(new Customer());

            mockCustomerRepo.Verify(m => m.InsertOrUpdate(It.IsAny<Customer>()));
            mockCustomerRepo.Verify(m => m.Save());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNullCustomer()
        {
            controller.Create(null);
        }

        [TestMethod()]
        public void EditUpdatesCustomerAndSaves()
        {
            controller.Edit(new Customer());

            mockCustomerRepo.Verify(m => m.InsertOrUpdate(It.IsAny<Customer>()));
            mockCustomerRepo.Verify(m => m.Save());
        }

        [TestMethod()]
        public void DeleteConfirmedDeletesCustomerAndSaves()
        {
            controller.DeleteConfirmed(1);

            mockCustomerRepo.Verify(m => m.Delete(It.IsAny<int>()));
            mockCustomerRepo.Verify(m => m.Save());
        }

        [TestMethod()]
        public void DeleteFindAndReturnsCustomer()
        {
            mockCustomerRepo.Setup(m => m.Find(It.IsAny<int>())).Returns(new Customer());

            var result = controller.Delete(1);

            mockCustomerRepo.Verify(m => m.Find(It.IsAny<int>()));
            Assert.IsInstanceOfType(((ViewResult)result).Model, typeof(Customer));
        }
    }
}
