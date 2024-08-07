using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Dynamic;

namespace FabrikamFiber.Web.IntegrationTests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void GetCustomers()
        {
            // arrange
            var wc = Helper.WebClient();

            // act
            var data = wc.DownloadString(Helper.WebUrl("/Api/Customers"));

            // assert
            // do a bit a parsing to make asserts easier
            var actual = Helper.ParseJson(data, new[] { new { id = 0, FirstName = "", LastName = "" } });
               
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count >= 11);
        }

        [TestMethod]
        public void GetEmployees()
        {
            // arrange
            var wc = Helper.WebClient();

            // act
            var data = wc.DownloadString(Helper.WebUrl("/Api/Employees"));

            // assert
            // do a bit a parsing to make asserts easier
            var actual = Helper.ParseJson(data, new[] { new { id = 0, FirstName = "", LastName = "" } });

            Assert.IsNotNull(actual);
            Assert.AreEqual(4, actual.Count);
        }

        [TestMethod]
        public void GetServiceTickets()
        {
            // arrange
            var wc = Helper.WebClient();

            // act
            var data = wc.DownloadString(Helper.WebUrl("/Api/ServiceTickets"));

            // assert
            // do a bit a parsing to make asserts easier
            var actual = Helper.ParseJson(data, new[] { new { id = 0, Status = "", Title = "" } });

            Assert.IsNotNull(actual);
            Assert.AreEqual(9, actual.Count);
        }
    }


}
