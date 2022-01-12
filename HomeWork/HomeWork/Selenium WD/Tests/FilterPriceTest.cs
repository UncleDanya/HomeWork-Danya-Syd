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
        private EntryCategory category;
        private FilterBrands filterBrands;
        private PriceSorting priceSortByDescendingPrice;
        private CheckboxRuntimeVariable checkboxRuntimeVariable = new CheckboxRuntimeVariable();
        private ProductPages productPages;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new EntryCategory(driver);
            filterBrands = new FilterBrands(driver, checkboxRuntimeVariable);
            priceSortByDescendingPrice = new PriceSorting(driver);
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void Test1()
        {
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            
            filterBrands.SearchBrandsByFilter("Apple");
            filterBrands.VerifyThatButtonIsCheckboxIsSelected("Apple");
            filterBrands.ClickOnShowFilter();

            productPages.SelectProductOnPage("Apple iPhone 13 Pro");
            productPages.ShowAllPriceOnProductButton.Click();
            productPages.SortByPrice.Click();

            Thread.Sleep(1000);
            
            priceSortByDescendingPrice.DescendingPriceFilter();
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
