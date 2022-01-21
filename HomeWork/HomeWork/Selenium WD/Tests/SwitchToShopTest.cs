using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.Steps;
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
            var product = driver.GetPage<ProductSteps>();

            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");

            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();

            /*productPages.SelectProductOnPage("Apple iPhone 13").Click();
            var nameProductText = productPages.FooterWithNameOnPage.Text.Replace("Мобильный телефон ", string.Empty).Replace(" ГБ", string.Empty);*/
            product.WhenUserSelectNeededProductOnPage("Apple iPhone 13");
            productPages.NameShopLinkText("Avic.ua").Click();
            product.WhenUserSwitchToNextPage();
            /*var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);*/
            /*var pageShopWithItemText = driver.FindElement(By.XPath("//h1[@class='page-title']")).Text;

            Assert.IsTrue(pageShopWithItemText.Contains(nameProductText));*/
            product.ThenVerifyThatProductNameInOtherShopEqualsToActualProductNameForMobileDevices();
        }
    }
}
