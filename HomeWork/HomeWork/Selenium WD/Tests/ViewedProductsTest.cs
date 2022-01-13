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
            mainPage = new MainPage();
            PageFactory.InitElements(driver, mainPage);
            userPage = new UserPage(driver);
            PageFactory.InitElements(driver, userPage);
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void Test1()
        {
            mainPage.CreateNewUserAccount();
            
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            
            filter.SearchBrandsByFilter("Apple");
            filter.VerifyThatCheckboxIsSelected("Apple");
            filter.ClickOnShowFilter();

            var nameMobileProductText = productPages.NameProductOnPage("Apple iPhone 13 Pro");
            productPages.SelectProductOnPage("Apple iPhone 13 Pro");
            
            category.EntryIntoCategoryByName("Компьютеры", "Приставки");
            
            filter.SearchBrandsByFilter("Sony");
            filter.VerifyThatCheckboxIsSelected("Sony");
            filter.ClickOnShowFilter();

            var nameConsoleProductText = productPages.NameProductOnPage("Sony PlayStation 5");
            productPages.SelectProductOnPage("Sony PlayStation 5");
            
            category.EntryIntoCategoryByName("Аудио", "Наушники");
            
            filter.SearchBrandsByFilter("Logitech");
            filter.VerifyThatCheckboxIsSelected("Logitech");
            filter.ClickOnShowFilter();

            var nameAudioProductText = productPages.NameProductOnPage("Logitech G Pro X");
            productPages.SelectProductOnPage("Logitech G Pro X");
            
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
