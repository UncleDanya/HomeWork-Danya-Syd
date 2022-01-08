using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork
{
    internal class ViewedProductsTest
    {
        private IWebDriver driver;
        private UserService service;
        private EntryCategory category;
        private FilterBrands filter;
        private MainPage mainPage;
        private PageMobileProductApple mobileProductApple;
        private PageMobileiPhone13Pro mobileiPhone13Pro;
        private PageHeadsetProductLogitech headsetProductLogitech;
        private PageConsoleProductSony consoleProductSony;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            service = new UserService(driver);
            category = new EntryCategory(driver);
            filter = new FilterBrands(driver);
            mainPage = new MainPage();
            PageFactory.InitElements(driver, mainPage);
            mobileProductApple = new PageMobileProductApple();
            PageFactory.InitElements(driver, mobileProductApple);
            mobileiPhone13Pro = new PageMobileiPhone13Pro();
            PageFactory.InitElements(driver, mobileiPhone13Pro);
            headsetProductLogitech = new PageHeadsetProductLogitech();
            PageFactory.InitElements(driver, headsetProductLogitech);
            consoleProductSony = new PageConsoleProductSony();
            PageFactory.InitElements(driver, consoleProductSony);
        }

        [Test]
        public void Test1()
        {
            //service.CreateNewUserAccount();
            mainPage.CreateNewUserAccount();
            // service.SaveInViewedProducts();
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            filter.SearchBrandsByFilter("Apple");
            var nameMobileProductText = mobileProductApple.NameProProductLink.Text;
            mobileProductApple.NameProProductLink.Click();

            category.EntryIntoCategoryByName("Компьютеры", "Приставки");
            filter.SearchBrandsByFilter("Sony");
            var nameConsoleProductText = consoleProductSony.NameProductOnConsolePage.Text;
            consoleProductSony.NameProductOnConsolePage.Click();

            category.EntryIntoCategoryByName("Аудио", "Наушники");
            filter.SearchBrandsByFilter("Logitech");
            var nameAudioProductText = headsetProductLogitech.NameProductOnHeadsetPage.Text;
            headsetProductLogitech.NameProductOnHeadsetPage.Click();

            mainPage.ActualLogin.Click();

            var nameMobileItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Apple iPhone 13 Pr...']")).Text.Remove(16);
            var nameConsoleItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Sony PlayStation 5']")).Text;
            var nameAudioItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Logitech G Pro X']")).Text;

            Assert.IsTrue(nameMobileProductText.Contains(nameMobileItemInList));
            Assert.IsTrue(nameConsoleProductText.Contains(nameConsoleItemInList));
            Assert.IsTrue(nameAudioProductText.Contains(nameAudioItemInList));
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
