using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FabrikamFiber.Web.SeleniumTests
{
    public class SeleniumPage 
    {
        public static readonly string Url = "http://localhost:16535/";
        public IWebDriver Driver { get; }

        public SeleniumPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public SeleniumPage GoTo(string url)
        {
            this.Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public IWebElement FindLink(string linkText)
        {
                return this.Driver.FindElement(By.PartialLinkText(linkText));
        }

        public IWebElement FindTextBox(string name)
        {
            return this.Driver.FindElement(By.Name(name));
        }

        public IWebElement FindButton(string linkText)
        {
            return this.Driver.FindElement(By.CssSelector(string.Format("input[value='{0}']",linkText)));
        }

        public int TableRowCount(string name)
        {
            return this.Driver.FindElements(By.XPath(string.Format("//table[@class='{0}']/tbody/tr", name))).Count;

        }
    }
}
