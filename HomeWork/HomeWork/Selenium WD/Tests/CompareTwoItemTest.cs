using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace HomeWork
{
    internal class CompareTwoItemTest
    {
        private IWebDriver driver;
        private EntryCategory category;
        private FilterBrands filter;
        private CompareProductPage compareProduct;
        private CheckboxRuntimeVariable checkboxRuntimeVariable = new CheckboxRuntimeVariable();
        private ProductPages productPages;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new EntryCategory(driver);
            filter = new FilterBrands(driver, checkboxRuntimeVariable);
            compareProduct = new CompareProductPage();
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
            PageFactory.InitElements(driver, compareProduct);
        }

        [Test]
        public void Test1()
        {
            category.EntryIntoCategoryByName("Компьютеры", "Планшеты");
            
            filter.SearchBrandsByFilter("Apple");
            filter.VerifyThatButtonIsCheckboxIsSelected("Apple");
            filter.ClickOnShowFilter();
            
            productPages.SelectProductOnPage("Apple iPad");
            var nameFirstTablet = productPages.FooterWithNameOnPage.Text;
            productPages.AddedToCompareCheckboxProduct.Click();
            
            Thread.Sleep(1000);
            
            var attribute = productPages.SwitchToPageWithTablet.GetAttribute("link");
            productPages.SwitchToPageWithTablet.Click();
            productPages.SelectProductOnPage("Apple iPad Air");
            var nameSecondTablet = productPages.FooterWithNameOnPage.Text;
            productPages.AddedToCompareCheckboxProduct.Click();
            
            Thread.Sleep(2000);
            
            productPages.SwitchToComparePage.Click();

            var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);

            var nameFirstTabletInComparePage = compareProduct.NameFirstCompareProduct.Text;
            var nameSecondTabletInComparePage = compareProduct.NameSecondCompareProduct.Text;

            Assert.IsTrue(nameFirstTabletInComparePage.Contains(nameFirstTablet), "The added item does not match the item on the list");
            Assert.IsTrue(nameSecondTabletInComparePage.Contains(nameSecondTablet), "The added item does not match the item on the list");
            Assert.AreEqual(attribute, "/list/30/apple/");
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
