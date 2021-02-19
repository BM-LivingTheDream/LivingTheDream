using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FabrikamFiber.DAL.Data;
using FabrikamFiber.Web.Controllers;
using System.Web.Mvc;

namespace FabrikamFiber.Web.UnitTests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexReturnsNonNullView()
        {
            var serviceTicketRepo = new Moq.Mock<IServiceTicketRepository>();
            var messageRepo = new Moq.Mock<IMessageRepository>();
            var alertRepo = new Moq.Mock <IAlertRepository>();
            var scheduleItemRepo = new Moq.Mock<IScheduleItemRepository>();

            var controller = new HomeController(
                serviceTicketRepo.Object as IServiceTicketRepository,
                messageRepo.Object as IMessageRepository,
                alertRepo.Object as IAlertRepository,
                scheduleItemRepo.Object as IScheduleItemRepository
            );

            var result = (ViewResult)controller.Index();
        }
    }
}
