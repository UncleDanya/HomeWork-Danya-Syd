using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Threading;

namespace HomeWork
{
    internal class SaveItemListTest
    {
        private IWebDriver driver;
        private MainPage mainPage;
        private EntryCategory category;
        private FilterBrands filter;
        private UserPage userPage;
        private CheckboxRuntimeVariable checkboxRuntimeVariable = new CheckboxRuntimeVariable();
        private ProductPages productPages;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            mainPage = new MainPage();
            PageFactory.InitElements(driver, mainPage);
            category = new EntryCategory(driver);
            filter = new FilterBrands(driver, checkboxRuntimeVariable);
            userPage = new UserPage(driver);
            PageFactory.InitElements(driver, userPage);
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void Test1()
        {
            mainPage.CreateNewUserAccount();
            
            category.EntryIntoCategoryByName("Аудио", "Наушники");
            
            filter.SearchBrandsByFilter("Logitech");
            filter.VerifyThatButtonIsCheckboxIsSelected("Logitech");
            filter.ClickOnShowFilter();

            var listWithNameProductOnPage = productPages.NamesOfAllProductsOnPage.SkipLast(4).Select(element => element.Text).ToList();
            listWithNameProductOnPage.Sort();
            productPages.SaveProductOnPage();
            
            Thread.Sleep(1000);
            
            mainPage.EnterUserPageButton.Click();
            userPage.ShowSaveProductList.Click();
            var listWithSaveProductInUserPage = productPages.NamesOfAllProductsOnPage.Select(element => element.Text).ToList();
            listWithSaveProductInUserPage.Sort();

            Assert.AreEqual(listWithNameProductOnPage, listWithSaveProductInUserPage, "The saved item sheet does not match the sheet in the profile");
        }

        [TearDown]
        public void Test2()
        {
            userPage.DeleteUserAccount();
            driver.Quit();
            driver.Dispose();
        }
    }
}
