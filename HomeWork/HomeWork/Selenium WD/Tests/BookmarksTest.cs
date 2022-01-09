using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace HomeWork
{
    internal class BookmarksTest
    {
        private IWebDriver driver;
        private EntryCategory category;
        private FilterBrands filter;
        private PageMobileProductApple pageMobile;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new EntryCategory(driver);
            filter = new FilterBrands(driver);
            pageMobile = new PageMobileProductApple();
            PageFactory.InitElements(driver, pageMobile);
        }

        [Test]
        public void Test1()
        {
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            filter.SearchBrandsByFilter("Apple");
            var tagName = pageMobile.NameProductLink.TagName;
            pageMobile.NameProductLink.Click();
            var nameTitleProduct = pageMobile.NameTitleProduct.Text;
            pageMobile.AddedProductInList.Click();

            Thread.Sleep(2000);

            pageMobile.OpenListWithProduct.Click();

            Thread.Sleep(2000);

            var nameProductInList = pageMobile.NameProductInList.Text;
            var textProductInList = nameProductInList.Replace("GB", string.Empty);

            Assert.IsTrue(nameTitleProduct.Contains(textProductInList), "The item added to the bookmark does not match the item in the bookmark");
            Assert.AreEqual(tagName, "span");
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
