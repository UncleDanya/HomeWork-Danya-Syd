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
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            searchField = new SearchField(driver);
        }

        [Test]
        public void Test1()
        {
            searchField.SearchFieldProductInput("iPhone 13 Pro 256");
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
