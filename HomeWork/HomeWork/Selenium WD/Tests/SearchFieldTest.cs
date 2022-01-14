using HomeWork.Selenium_WD.Functional;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork
{
    internal class SearchFieldTest
    {
        private IWebDriver driver;
        private SearchField searchField;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            searchField = new SearchField(driver);
        }

        [Test]
        public void TestSearchField()
        {
            searchField.SearchFieldProductInput("iPhone 13 Pro 256");
        }

        [TearDown]
        public void Completion()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
