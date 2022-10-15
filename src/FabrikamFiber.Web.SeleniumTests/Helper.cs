using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace FabrikamFiber.Web.SeleniumTests
{
    internal class Helper
    {
        internal static Uri WebUrl
        {
            get
            {
                return new Uri(GetWebConfigSetting("weburi"));
            }
        }

        internal static IWebDriver GetWebDriver()
        {
            var driverName = GetWebConfigSetting("webdriver");
            switch (driverName)
            {
                case "Chrome":
                    return new ChromeDriver();
                case "Firefox":
                    return new FirefoxDriver();
                case "IE":
                    return new InternetExplorerDriver();
                default:
                    throw new ConfigurationErrorsException($"{driverName} is not a know Selenium WebDriver");
            }
        }

        private static string GetWebConfigSetting(string name)
        {
            var value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                throw new ConfigurationErrorsException($"No AppSettings {name} defined");
            }
            return value;
        }
    }
}
