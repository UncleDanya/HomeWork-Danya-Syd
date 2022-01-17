using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork
{
    internal class SwitchToShopTest
    {
        private RemoteWebDriver driver;
        private ProductCategoryNavigation category;
        CategoryPage categoryPage;
        private CheckboxRuntimeVariable checkboxRuntimeVariable = new CheckboxRuntimeVariable();
        private ProductPages productPages;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new ProductCategoryNavigation(driver);
            categoryPage = new CategoryPage(driver, checkboxRuntimeVariable);
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void TestSwitchToShop()
        {
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");

            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();

            productPages.SelectProductOnPage("Apple iPhone 13").Click();
            var nameProductText = productPages.FooterWithNameOnPage.Text.Replace("Мобильный телефон ", string.Empty).Replace(" ГБ", string.Empty);
            productPages.NameShopLinkText("Avic.ua").Click();
            var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);
            var pageShopWithItemText = driver.FindElement(By.XPath("//h1[@class='page-title']")).Text;

            Assert.IsTrue(pageShopWithItemText.Contains(nameProductText));
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
