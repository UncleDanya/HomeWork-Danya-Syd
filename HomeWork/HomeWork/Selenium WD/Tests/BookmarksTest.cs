using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace HomeWork
{
    internal class BookmarksTest
    {
        private IWebDriver driver;
        private ProductCategoryNavigation category;
        private CategoryPage categoryPage;
        private CheckboxRuntimeVariable checkboxRuntimeVariables = new CheckboxRuntimeVariable();
        private ProductPages productPages;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            category = new ProductCategoryNavigation(driver);
            categoryPage = new CategoryPage(driver, checkboxRuntimeVariables);
            productPages = new ProductPages(driver);
            PageFactory.InitElements(driver, productPages);
        }

        [Test]
        public void TestBookmarks()
        {
            Actions actions = new Actions(driver);
            
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");

            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();

            Thread.Sleep(1000);

            var tagName = productPages.AddedProductInList.TagName;
            productPages.SelectProductOnPage("Apple iPhone 13").Click();

            var addedContantButton = driver.FindElement(By.XPath(".//div[starts-with(@class, 'i15-add-content i15-img h')]"));
            var locationButton = addedContantButton.Location.X;
            var sizeButton = addedContantButton.Size.Width + locationButton; 
            actions.MoveToElement(addedContantButton).Perform();
            var sizeAfterMove = addedContantButton.Size;
            Assert.AreNotEqual(sizeAfterMove, sizeButton, "Button added content not work");
            
            var nameTitleProduct = productPages.FooterWithNameOnPage.Text;
            productPages.AddedProductInList.Click();

            Thread.Sleep(2000);

            productPages.OpenListWithProduct.Click();

            Thread.Sleep(2000);

            var nameProductInList = productPages.NameProductInSaveList.Text;
            var textProductInList = nameProductInList.Replace("GB", string.Empty);

            Assert.IsTrue(nameTitleProduct.Contains(textProductInList), "The item added to the bookmark does not match the item in the bookmark");
            Assert.AreEqual(tagName, "span");
        }

        [TearDown]
        public void Completion()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
