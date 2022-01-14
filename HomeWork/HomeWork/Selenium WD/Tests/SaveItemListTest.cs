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
        private ProductCategoryNavigation category;
        CategoryPage categoryPage;
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
            category = new ProductCategoryNavigation(driver);
            categoryPage = new CategoryPage(driver, checkboxRuntimeVariable);
            userPage = new UserPage(driver);
            PageFactory.InitElements(driver, userPage);
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void TestSaveItemList()
        {
            mainPage.CreateNewUserAccount();
            
            category.EntryIntoCategoryByName("Аудио", "Наушники");

            categoryPage.SearchBrandByFilter("Logitech");
            categoryPage.VerifyThatCheckboxIsSelected("Logitech");
            categoryPage.ClickOnShowFilterButton();

            var listWithNameProductOnPage = productPages.NamesOfAllProductsOnPage.SkipLast(4).Select(element => element.Text).ToList();
            listWithNameProductOnPage.Sort();
            productPages.SaveListProductOnPage.Click();
            productPages.SubmitButtonSaveList.Click();
            
            Thread.Sleep(1000);
            
            mainPage.EnterUserPageButton.Click();
            userPage.ShowSaveProductList.Click();
            var listWithSaveProductInUserPage = productPages.NamesOfAllProductsOnPage.Select(element => element.Text).ToList();
            listWithSaveProductInUserPage.Sort();

            Assert.AreEqual(listWithNameProductOnPage, listWithSaveProductInUserPage, "The saved item list does not match the sheet in the profile");
        }

        [TearDown]
        public void Completion()
        {
            userPage.DeleteUserAccount();
            driver.Quit();
            driver.Dispose();
        }
    }
}
