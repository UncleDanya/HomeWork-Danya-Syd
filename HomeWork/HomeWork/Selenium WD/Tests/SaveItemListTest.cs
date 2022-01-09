using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;

namespace HomeWork
{
    internal class SaveItemListTest
    {
        private IWebDriver driver;
        private MainPage mainPage;
        private EntryCategory category;
        private FilterBrands filter;
        private PageHeadsetProductLogitech pagaHeadset;
        private UserPage userPage;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            mainPage = new MainPage();
            PageFactory.InitElements(driver, mainPage);
            category = new EntryCategory(driver);
            filter = new FilterBrands(driver);
            pagaHeadset = new PageHeadsetProductLogitech();
            PageFactory.InitElements(driver, pagaHeadset);
            userPage = new UserPage();
            PageFactory.InitElements(driver, userPage);
        }

        [Test]
        public void Test1()
        {
            mainPage.CreateNewUserAccount();
            category.EntryIntoCategoryByName("Аудио", "Наушники");
            filter.SearchBrandsByFilter("Logitech");
            var listWithNameProductOnPage = pagaHeadset.NameAllProductInPage.SkipLast(4).Select(element => element.Text).ToList();
            listWithNameProductOnPage.Sort();
            pagaHeadset.SaveListProductButton.Click();
            pagaHeadset.SubmitSaveProductListButton.Click();
            mainPage.EnterUserPageButton.Click();
            userPage.ShowSaveProductList.Click();
            var listWithSaveProductInUserPage = pagaHeadset.NameAllProductInPage.Select(element => element.Text).ToList();
            listWithSaveProductInUserPage.Sort();

            Assert.AreEqual(listWithNameProductOnPage, listWithSaveProductInUserPage, "The saved item sheet does not match the sheet in the profile");
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
