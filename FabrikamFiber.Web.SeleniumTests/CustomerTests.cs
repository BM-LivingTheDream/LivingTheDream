using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System.Drawing;

namespace FabrikamFiber.Web.SeleniumTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void AddCustomer()
        {
            using (var driver = new PhantomJSDriver())
            {
                var page = new SeleniumPage(driver);

                page.GoTo(Helper.WebUrl.ToString());

                page.FindLink("Customers").Click();

                int oldRowCount = page.TableRowCount("dataTable");

                page.FindLink("Create New").Click();
                page.FindTextBox("FirstName").SendKeys("Fred");
                page.FindTextBox("LastName").SendKeys("Bloggs");
                page.FindTextBox("Address.Street").SendKeys("1 The Road");
                page.FindTextBox("Address.City").SendKeys("Townsville");
                page.FindTextBox("Address.State").SendKeys("Countyshire");
                page.FindTextBox("Address.Zip").SendKeys("12345");
                page.FindButton("Create").Click();

                var newRowCount = page.TableRowCount("dataTable");

                Assert.IsTrue(newRowCount - oldRowCount == 1);

                driver.Quit();
            }

        }
    }
}
