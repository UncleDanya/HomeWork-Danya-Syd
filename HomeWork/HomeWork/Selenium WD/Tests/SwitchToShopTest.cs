using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork
{
    internal class SwitchToShopTest : BaseTest
    {

        [Test]
        public void TestSwitchToShop()
        {
            var categoryPage = driver.GetPage<CategoryPage>();
            var category = driver.GetPage<ProductCategoryNavigation>();
            var productPages = driver.GetPage<ProductPages>();

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
    }
}
