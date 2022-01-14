using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace HomeWork
{
    internal class FilterPriceTest
    {
        private IWebDriver driver;
        private ProductCategoryNavigation category;
        CategoryPage categoryPage;
        private PriceSorting priceSortByDescendingPrice;
        private CheckboxRuntimeVariable checkboxRuntimeVariable = new CheckboxRuntimeVariable();
        private ProductPages productPages;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new ProductCategoryNavigation(driver);
            categoryPage = new CategoryPage(driver, checkboxRuntimeVariable);
            priceSortByDescendingPrice = new PriceSorting(driver);
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void TestFilterPrice()
        {
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");

            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();

            productPages.SelectProductOnPage("Apple iPhone 13 Pro").Click();
            productPages.ShowAllPriceOnProductButton.Click();

            Thread.Sleep(1000);
            
            priceSortByDescendingPrice.VerifyPriceDescendingPriceSorting();
        }

        [TearDown]
        public void Completion()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
