using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork
{
    internal class FilterTest
    {
        private IWebDriver driver;
        private ProductCategoryNavigation category;
        CategoryPage categoryPage;
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
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void TestFilter()
        {
            category.EntryIntoCategoryByName("Компьютеры", "Ноутбуки");

            categoryPage.SearchBrandByFilter("Acer");
            categoryPage.VerifyThatCheckboxIsSelected("Acer");
            categoryPage.ClickOnShowFilterButton();

            productPages.VerifyFilterShowActualBrand("Acer");
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
