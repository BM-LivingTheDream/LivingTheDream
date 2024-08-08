using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace FabrikamFiber.Web.UXTests
{
    [TestClass]
    public class CustomertTest : PageTest
    {
        IConfigurationSection appSettings = null!;

        [TestInitialize]
        public void Init()
        {
            IConfigurationRoot builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            appSettings = builder.GetSection("AppSettings");
        }

        [TestMethod]
        public async Task CanAddCustomer()
        {
            await Page.GotoAsync(appSettings["TestUrl"]!);

            await Page.GetByText("Customers").ClickAsync();

            await Page.WaitForTimeoutAsync(5000);

            int oldRowCount = await Page.Locator(".dataTable").Locator("tr").CountAsync();
            Console.WriteLine($"Pre-test row count: {oldRowCount}");

            await Page.GetByText("Create New").ClickAsync();
            await Page.Locator("#FirstName").FillAsync("Fred");
            await Page.Locator("#LastName").FillAsync("Bloggs");
            await Page.Locator("#Address_Street").FillAsync("1 The Road");
            await Page.Locator("#Address_City").FillAsync("Townsville");
            await Page.Locator("#Address_State").FillAsync("Countyshire");
            await Page.Locator("#Address_Zip").FillAsync("12345");
            await Page.Locator("input[type='submit'][value='Create']").ClickAsync();

            await Page.WaitForTimeoutAsync(5000);

            var newRowCount = await Page.Locator(".dataTable").Locator("tr").CountAsync();
            Console.WriteLine($"Post-test row count: {newRowCount}");
            
            Assert.IsTrue(newRowCount - oldRowCount == 1);

        }
    }
}
