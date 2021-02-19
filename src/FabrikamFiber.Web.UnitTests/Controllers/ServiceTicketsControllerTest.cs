using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FabrikamFiber.DAL.Data;
using Moq;
using FabrikamFiber.Web.Controllers;
using System.Collections.Generic;
using FabrikamFiber.DAL.Models;
using System.Linq;
using System.Web.Mvc;
using FabrikamFiber.Web.ViewModels;
using System.Linq.Expressions;
using Microsoft.CSharp;

namespace FabrikamFiber.Web.UnitTests.Controllers
{
    [TestClass]
    public class ServiceTicketsControllerTest
    {
        Mock<ICustomerRepository> mockCustomerRepo;
        Mock<IEmployeeRepository> mockEmployeeRepo;
        Mock<IServiceTicketRepository> mockServiceTicketRepo;
        Mock<IServiceLogEntryRepository> mockLogEntryRepo;
        Mock<IScheduleItemRepository> mockScheduleItemRepo;

        ServiceTicketsController controller;

        [TestInitialize]
        public void SetupController()
        {
            mockCustomerRepo = new Mock<ICustomerRepository>();
            mockEmployeeRepo = new Mock<IEmployeeRepository>();
            mockServiceTicketRepo = new Mock<IServiceTicketRepository>();
            mockLogEntryRepo = new Mock<IServiceLogEntryRepository>();
            mockScheduleItemRepo = new Mock<IScheduleItemRepository>();

            controller = new ServiceTicketsController(
                mockCustomerRepo.Object as ICustomerRepository,
                mockEmployeeRepo.Object as IEmployeeRepository,
                mockServiceTicketRepo.Object as IServiceTicketRepository,
                mockLogEntryRepo.Object as IServiceLogEntryRepository,
                mockScheduleItemRepo.Object as IScheduleItemRepository
            );
        }

        [TestMethod]
        public void ScheduleActionReturnsValidViewModel()
        {
            this.SetupController();

            // Arrange
            // have to use 3 params as cannot work out how to make the callbacks an array
            mockServiceTicketRepo.Setup(m => m.FindIncluding(
                It.IsAny<int>(), 
                It.IsAny<Expression<Func<ServiceTicket,object>>>(),
                It.IsAny<Expression<Func<ServiceTicket, object>>>(),
                It.IsAny<Expression<Func<ServiceTicket, object>>>())
                ).Returns(new ServiceTicket { ID = 1 });

            mockEmployeeRepo.Setup(
                m => m.Find(1)
                ).Returns(new Employee { ID = 1 });

            var scheduleItems = new List<ScheduleItem>();

            scheduleItems.Add(new ScheduleItem { ID = 1, });
            mockScheduleItemRepo.Setup(m => m.AllIncluding(
                It.IsAny<Expression<Func<ScheduleItem, object>>>())
                ).Returns(scheduleItems.AsQueryable<ScheduleItem>());

            // Act
            var result = (ViewResult)controller.Schedule(1, 1, 0);

            // Assert
            var model = result.ViewData.Model as ScheduleViewModel;
            Assert.IsNotNull(model.Employee, "No employee");
            Assert.IsNotNull(model.ScheduleItems, "No schedule item");
            Assert.IsNotNull(model.ServiceTicket, "No service ticket");
            controller.ViewBag.StartTime = 0;
        }

        [TestMethod]
        public void ScheduleActionCorrectlyUpdatesRepositories()
        {
            this.SetupController();

            // Arrange
            var serviceTicketID = 1;
            var scheduleItems = new List<ScheduleItem>();
            scheduleItems.Add(new ScheduleItem { ServiceTicketID = serviceTicketID });
             mockScheduleItemRepo.Setup(m => m.InsertOrUpdate(It.IsAny<ScheduleItem>()));
             mockScheduleItemRepo.Setup(m => m.Delete(It.IsAny<int>()));
    
            ServiceTicket ticket = new ServiceTicket { ID = 0 };
            mockServiceTicketRepo.Setup(m => m.Find(serviceTicketID)).Returns(ticket);
    
            // Act
            controller.AssignSchedule(1, 101, 0);

            // Assert
            Assert.AreEqual(101, ticket.AssignedToID);
            mockScheduleItemRepo.Verify( m => m.InsertOrUpdate(It.IsAny<ScheduleItem>()));
            mockScheduleItemRepo.Verify(m => m.Save());
            mockServiceTicketRepo.Verify(m => m.Save());
                  
        }
    }
}
