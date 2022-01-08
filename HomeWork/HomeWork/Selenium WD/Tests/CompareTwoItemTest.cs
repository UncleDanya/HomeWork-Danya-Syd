using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;

namespace HomeWork
{
    internal class CompareTwoItemTest
    {
        private IWebDriver driver;
        private UserService service;
        private EntryCategory category;
        private FilterBrands filter;
        private PageTabletProductApple tabletProductApple;
        private PageTabletAppleiPad2021 tabletAppleiPad2021;
        private PageTabletAppleiPadAir2020 tabletAppleiPadAir2020;
        private CompareProductPage compareProduct;
        
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            service = new UserService(driver);
            category = new EntryCategory(driver);
            filter = new FilterBrands(driver);
            tabletAppleiPad2021 = new PageTabletAppleiPad2021();
            tabletAppleiPadAir2020 = new PageTabletAppleiPadAir2020();
            tabletProductApple = new PageTabletProductApple();
            compareProduct = new CompareProductPage();
            PageFactory.InitElements(driver, tabletAppleiPad2021);
            PageFactory.InitElements(driver, tabletAppleiPadAir2020);
            PageFactory.InitElements(driver, tabletProductApple);
            PageFactory.InitElements(driver, compareProduct);
        }

        [Test]
        public void Test1()
        {
            // service.EntryIntoCategoryByName("Компьютеры", "Планшеты");
            category.EntryIntoCategoryByName("Компьютеры", "Планшеты");
            // service.SearchBrandsByFilter("Apple");
            filter.SearchBrandsByFilter("Apple");
            // service.CompareTest();
            var nameFirstTablet = tabletProductApple.FirstTabletToCompare.Text;
            tabletProductApple.FirstTabletToCompare.Click();

            tabletAppleiPad2021.AddedToCompareButton.Click();
            tabletAppleiPad2021.SwitchToPageWithTablet.Click();

            var nameSecondTablet = tabletProductApple.SecondTabletToCompate.Text;
            tabletProductApple.SecondTabletToCompate.Click();

            tabletAppleiPadAir2020.AddedToCompareButton.Click();
            tabletAppleiPadAir2020.SwitchToComparePage.Click();

            var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);

            var nameFirstTabletInComparePage = compareProduct.NameFirstCompareProduct.Text;
            var nameSecondTabletInComparePage = compareProduct.NameSecondCompareProduct.Text;

            Assert.IsTrue(nameFirstTabletInComparePage.Contains(nameFirstTablet), "The added item does not match the item on the list");
            Assert.IsTrue(nameSecondTabletInComparePage.Contains(nameSecondTablet), "The added item does not match the item on the list");


        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
