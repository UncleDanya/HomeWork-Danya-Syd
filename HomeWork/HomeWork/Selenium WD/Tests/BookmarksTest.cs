using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
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
        private CheckboxRuntimeVariable checkboxRuntimeVariables = new CheckboxRuntimeVariable();
        private ProductPages productPages;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new EntryCategory(driver);
            filter = new FilterBrands(driver, checkboxRuntimeVariables);
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void Test1()
        {
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            
            filter.SearchBrandsByFilter("Apple");
            filter.VerifyThatCheckboxIsSelected("Apple");
            filter.ClickOnShowFilter();

            Thread.Sleep(1000);

            var tagName = productPages.AddedProductInList.TagName;
            productPages.SelectProductOnPage("Apple iPhone 13");

            var nameTitleProduct = productPages.FooterWithNameOnPage.Text;
            productPages.AddedProductInList.Click();

            Thread.Sleep(2000);

            productPages.OpenListWithProduct.Click();

            Thread.Sleep(2000);

            var nameProductInList = productPages.NameProductInSaveList.Text;
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
