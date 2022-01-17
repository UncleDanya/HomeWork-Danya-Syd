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
        private ProductCategoryNavigation category;
        private CategoryPage categoryPage;
        private MainPage mainPage;
        private UserPage userPage;
        private CheckboxRuntimeVariable checkboxRuntimeVariable = new CheckboxRuntimeVariable();
        private ProductPages productPages;
        private RandomLoginVariable randomLoginVariable = new RandomLoginVariable();

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new ProductCategoryNavigation(driver);
            categoryPage = new CategoryPage(driver, checkboxRuntimeVariable);
            mainPage = new MainPage(randomLoginVariable);
            PageFactory.InitElements(driver, mainPage);
            userPage = new UserPage(driver);
            PageFactory.InitElements(driver, userPage);
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void TestViewedProducts()
        {
            mainPage.CreateNewUserAccount();
            
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");

            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();

            var nameMobileProductText = productPages.SelectProductOnPage("Apple iPhone 13 Pro").Text;
            productPages.SelectProductOnPage("Apple iPhone 13 Pro").Click();
            
            category.EntryIntoCategoryByName("Компьютеры", "Приставки");

            categoryPage.SearchBrandByFilter("Sony");
            categoryPage.VerifyThatCheckboxIsSelected("Sony");
            categoryPage.ClickOnShowFilterButton();

            var nameConsoleProductText = productPages.SelectProductOnPage("Sony PlayStation 5").Text;
            productPages.SelectProductOnPage("Sony PlayStation 5").Click();
            
            category.EntryIntoCategoryByName("Аудио", "Наушники");

            categoryPage.SearchBrandByFilter("Logitech");
            categoryPage.VerifyThatCheckboxIsSelected("Logitech");
            categoryPage.ClickOnShowFilterButton();

            var nameAudioProductText = productPages.SelectProductOnPage("Logitech G Pro X").Text;
            productPages.SelectProductOnPage("Logitech G Pro X").Click();
            
            mainPage.ActualLogin.Click();
            var nameMobileItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Apple iPhone 13 Pr...']")).Text.Remove(16);
            var nameConsoleItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Sony PlayStation 5']")).Text;
            var nameAudioItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Logitech G Pro X']")).Text;

            Assert.IsTrue(nameMobileProductText.Contains(nameMobileItemInList));
            Assert.IsTrue(nameConsoleProductText.Contains(nameConsoleItemInList));
            Assert.IsTrue(nameAudioProductText.Contains(nameAudioItemInList));
        }

        [TearDown]
        public void AfterTest()
        {
            userPage.DeleteUserAccount();
            driver.Quit();
            driver.Dispose();
        }
    }
}
