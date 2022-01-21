using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using HomeWork.Selenium_WD.Utils;

namespace HomeWork
{
    internal class BookmarksTest : BaseTest
    {

        [Test]
        public void TestBookmarks()
        {
            Actions actions = new Actions(driver);

            var productPages = driver.GetPage<ProductPages>();
            var category = driver.GetPage<ProductCategoryNavigation>();
            var categoryPage = driver.GetPage<CategoryPage>();
            var product = driver.GetPage<ProductSteps>();
            
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();

            product.WhenUserSelectNeededProductOnPage("Apple iPhone 13");
            product.WhenUserAddedProductInList();
            product.WhenUserOpenBookmarksMenu();
            product.ThenVerifyThatProductNameInBookmarksMenuEqualsToActualProductNameForMobileDevices();

            // WaitUtils.WaitForElementToBeClickable(driver, productPages.SelectProductOnPage("Apple iPhone 13"));

            // var tagName = productPages.AddedProductInList.TagName;
            // productPages.SelectProductOnPage("Apple iPhone 13").Click();

            /*var addedContantButton = driver.FindElement(By.XPath(".//div[starts-with(@class, 'i15-add-content i15-img h')]"));
            var locationButton = addedContantButton.Location.X;
            var sizeButton = addedContantButton.Size.Width + locationButton; 
            actions.MoveToElement(addedContantButton).Perform();
            var sizeAfterMove = addedContantButton.Size;
            Assert.AreNotEqual(sizeAfterMove, sizeButton, "Button added content not work");*/

            /*var nameTitleProduct = productPages.FooterWithNameOnPage.Text;
            productPages.AddedProductInList.Click();

            WaitUtils.WaitForElementToBeClickable(driver, productPages.OpenListWithProduct);

            productPages.OpenListWithProduct.Click();

            var productNameInSaveList = WaitUtils.WaitForElementToBeDisplayed(driver, productPages.NameProductInSaveList);

            var nameProductInList = productNameInSaveList.Text;
            var textProductInList = nameProductInList.Replace("GB", string.Empty);

            Assert.IsTrue(nameTitleProduct.Contains(textProductInList), "The item added to the bookmark does not match the item in the bookmark");*/
            // Assert.AreEqual(tagName, "span");
        }
    }
}
