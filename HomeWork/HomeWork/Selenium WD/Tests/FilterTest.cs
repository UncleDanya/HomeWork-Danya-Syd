using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Linq;

namespace HomeWork
{
    internal class FilterTest
    {
        private IWebDriver driver;
        private EntryCategory category;
        private FilterBrands filterBrands;
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
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void Test1()
        {
            category.EntryIntoCategoryByName("Компьютеры", "Ноутбуки");
            
            filterBrands.SearchBrandsByFilter("Acer");
            filterBrands.VerifyThatButtonIsCheckboxIsSelected("Acer");
            filterBrands.ClickOnShowFilter();

            productPages.VerifyFilterShowActualBrand("Acer");
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
