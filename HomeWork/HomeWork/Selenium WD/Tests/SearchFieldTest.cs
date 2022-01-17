using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Functional;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork
{
    internal class SearchFieldTest : BaseTest
    {
        // private RemoteWebDriver driver;
        private SearchField searchField;

        /*[SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            searchField = new SearchField(driver);
        }*/

        [Test]
        public void TestSearchField()
        {
            searchField = new SearchField(driver);
            
            searchField.SearchFieldProductInput("iPhone 13 Pro 256");
            searchField.VerifyItemForSeraching("iPhone 13 Pro 256");
        }

        /*[TearDown]
        public void AfterTest()
        {
            driver.Quit();
            driver.Dispose();
        }*/
    }
}
