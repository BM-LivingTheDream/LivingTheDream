using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace FabrikamFiber.Web.CodedUI
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CustomerTests
    {
        public CustomerTests()
        {
        }

        [TestMethod]
        public void AddCustomer()
        {
            using (var bw = BrowserWindow.Launch(Helper.WebUrl))
            {
                FindAndClickLink(bw, "Customers");
                var oldRowCount = FindTableRowCount(bw, "dataTable");

                FindAndClickLink(bw, "Create New");
                FindAndTypeInTextBox(bw, "FirstName", "Fred");
                FindAndTypeInTextBox(bw, "LastName", "Bloggs");
                FindAndTypeInTextBox(bw, "Address.Street", "1 The Road");
                FindAndTypeInTextBox(bw, "Address.City", "Townsville");
                FindAndTypeInTextBox(bw, "Address.State", "Countyshire");
                FindAndTypeInTextBox(bw, "Address.Zip", "12345");
                FindAndClickButton(bw, "Create");

                var newRowCount = FindTableRowCount(bw, "dataTable");

                Assert.IsTrue(newRowCount - oldRowCount == 1);
          
            }

        }

        private int FindTableRowCount(BrowserWindow bw, string name)
        {
            var table = new HtmlTable(bw);
            table.SearchProperties.Add(HtmlTable.PropertyNames.Class, name);
            table.FindMatchingControls();
            return table.RowCount;
        }


        private void FindAndClickLink(BrowserWindow bw, string innerText)
        {
            var link = new HtmlHyperlink(bw);
            link.SearchProperties.Add(HtmlHyperlink.PropertyNames.TagName, "A");
            link.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, innerText);
            link.FindMatchingControls();
            Mouse.Click(link);
        }

        private void FindAndClickButton(BrowserWindow bw, string value)
        {
            var button = new HtmlInputButton(bw);
            button.SearchProperties.Add(HtmlInputButton.PropertyNames.ValueAttribute, value);
            button.FindMatchingControls();
            Mouse.Click(button);
        }

        private void FindAndTypeInTextBox(BrowserWindow bw, string name, string text)
        {
            var field = new HtmlEdit(bw);
            field.SearchProperties.Add(HtmlEdit.PropertyNames.Name, name);
            field.FindMatchingControls();
            field.Text = text;
        }


        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
