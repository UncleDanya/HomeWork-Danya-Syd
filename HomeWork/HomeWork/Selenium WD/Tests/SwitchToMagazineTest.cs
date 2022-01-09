using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork
{
    internal class SwitchToMagazineTest
    {
        private IWebDriver driver;
        private EntryCategory category;
        private FilterBrands filter;
        private PageMobileProductApple pageMobile;
        private PageProductAppleiPhone13 pageAppleiPhone13;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new EntryCategory(driver);
            filter = new FilterBrands(driver);
            pageMobile = new PageMobileProductApple();
            PageFactory.InitElements(driver, pageMobile);
            pageAppleiPhone13 = new PageProductAppleiPhone13();
            PageFactory.InitElements(driver, pageAppleiPhone13);
        }

        [Test]
        public void Test1()
        {
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            filter.SearchBrandsByFilter("Apple");
            pageMobile.NameProductLink.Click();
            var nameProductText = pageAppleiPhone13.FullNameProductOnPage.Text.Replace("Мобильный телефон ", string.Empty).Replace(" ГБ", string.Empty);
            pageAppleiPhone13.NameShopLinkText.Click();
            var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);
            var pageShopWithItemText = driver.FindElement(By.XPath("//h1[@class='page-title']")).Text;

            Assert.IsTrue(pageShopWithItemText.Contains(nameProductText));
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
