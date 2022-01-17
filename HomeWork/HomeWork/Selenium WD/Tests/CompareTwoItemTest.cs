using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace HomeWork
{
    internal class CompareTwoItemTest : BaseTest
    {
        // private RemoteWebDriver driver;
        private ProductCategoryNavigation category;
        private CategoryPage categoryPage;
        private CompareProductPage compareProduct;
        private CheckboxRuntimeVariable checkboxRuntimeVariable = new CheckboxRuntimeVariable();
        private ProductPages productPages;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new ProductCategoryNavigation(driver);
            categoryPage = new CategoryPage(checkboxRuntimeVariable);
            compareProduct = new CompareProductPage();
            productPages = new ProductPages();
            PageFactory.InitElements(driver, productPages);
            PageFactory.InitElements(driver, compareProduct);
        }

        [Test]
        public void TestCompareTwoItem()
        {
            category.EntryIntoCategoryByName("Компьютеры", "Планшеты");
            
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();
            
            productPages.SelectProductOnPage("Apple iPad").Click();
            var nameFirstTablet = productPages.FooterWithNameOnPage.Text;
            productPages.AddedToCompareCheckboxProduct.Click();
            
            Thread.Sleep(1000);
            
            var attribute = productPages.SwitchToPageWithTablet.GetAttribute("link");
            productPages.SwitchToPageWithTablet.Click();
            productPages.SelectProductOnPage("Apple iPad Air").Click();
            var nameSecondTablet = productPages.FooterWithNameOnPage.Text;
            productPages.AddedToCompareCheckboxProduct.Click();
            
            Thread.Sleep(2000);
            
            productPages.SwitchToComparePage.Click();

            var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);

            var nameFirstTabletInComparePage = compareProduct.NameProductForCompare("Apple iPad 2021").Text;
            var nameSecondTabletInComparePage = compareProduct.NameProductForCompare("Apple iPad Air").Text;

            Assert.IsTrue(nameFirstTabletInComparePage.Contains(nameFirstTablet), "The added item does not match the item on the list");
            Assert.IsTrue(nameSecondTabletInComparePage.Contains(nameSecondTablet), "The added item does not match the item on the list");
            Assert.AreEqual(attribute, "/list/30/apple/");
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
