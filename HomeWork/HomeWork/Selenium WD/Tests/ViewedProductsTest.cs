using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork
{
    internal class ViewedProductsTest
    {
        private IWebDriver driver;
        private EntryCategory category;
        private FilterBrands filter;
        private MainPage mainPage;
        private UserPage userPage;
        private PageMobileProductApple mobileProductApple;
        private PageMobileiPhone13Pro mobileiPhone13Pro;
        private PageHeadsetProductLogitech headsetProductLogitech;
        private PageConsoleProductSony consoleProductSony;
        private CheckboxRuntimeVariable checkboxRuntimeVariable = new CheckboxRuntimeVariable();

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new EntryCategory(driver);
            filter = new FilterBrands(driver, checkboxRuntimeVariable);
            mainPage = new MainPage();
            PageFactory.InitElements(driver, mainPage);
            userPage = new UserPage(driver);
            PageFactory.InitElements(driver, filter);
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
            mainPage.CreateNewUserAccount();
            
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            
            filter.SearchBrandsByFilter("Apple");
            filter.VerifyThatButtonIsCheckboxIsSelected("Apple");
            filter.ClickOnShowFilter();
            
            var nameMobileProductText = mobileProductApple.NameProProductLink.Text;
            mobileProductApple.NameProProductLink.Click();
            
            category.EntryIntoCategoryByName("Компьютеры", "Приставки");
            
            filter.SearchBrandsByFilter("Sony");
            filter.VerifyThatButtonIsCheckboxIsSelected("Sony");
            filter.ClickOnShowFilter();
            
            var nameConsoleProductText = consoleProductSony.NameProductOnConsolePage.Text;
            consoleProductSony.NameProductOnConsolePage.Click();
            
            category.EntryIntoCategoryByName("Аудио", "Наушники");
            
            filter.SearchBrandsByFilter("Logitech");
            filter.VerifyThatButtonIsCheckboxIsSelected("Logitech");
            filter.ClickOnShowFilter();
            
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
            userPage.DeleteUserAccount();
            driver.Quit();
            driver.Dispose();
        }
    }
}
