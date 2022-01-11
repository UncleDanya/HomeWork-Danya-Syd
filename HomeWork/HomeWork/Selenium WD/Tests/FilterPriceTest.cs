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
        private PageMobileProductApple pageMobileProductApple;
        private PageMobileiPhone13Pro pageMobileiPhone13Pro;
        private SortByDescendingPrice priceSortByDescendingPrice;
        private CheckboxRuntimeVariable checkboxRuntimeVariable = new CheckboxRuntimeVariable();

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new EntryCategory(driver);
            filterBrands = new FilterBrands(driver, checkboxRuntimeVariable);
            pageMobileProductApple = new PageMobileProductApple();
            PageFactory.InitElements(driver, pageMobileProductApple);
            pageMobileiPhone13Pro = new PageMobileiPhone13Pro();
            PageFactory.InitElements(driver, pageMobileiPhone13Pro);
            priceSortByDescendingPrice = new SortByDescendingPrice(driver);
        }

        [Test]
        public void Test1()
        {
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            
            filterBrands.SearchBrandsByFilter("Apple");
            filterBrands.VerifyThatButtonIsCheckboxIsSelected("Apple");
            filterBrands.ClickOnShowFilter();
            
            pageMobileProductApple.NameProProductLink.Click();
            pageMobileiPhone13Pro.ShowAllPriceProductButton.Click();
            pageMobileiPhone13Pro.SortByPrice.Click();
            
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
