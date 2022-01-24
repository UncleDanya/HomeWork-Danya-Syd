using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    internal class BookmarksTest : BaseTest
    {

        [Test]
        public void TestBookmarks()
        {
            var category = driver.GetPage<ProductCategoryNavigation>();
            var categoryPage = driver.GetPage<CategoryPage>();
            var product = driver.GetPage<ProductSteps>();
            
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Apple iPhone 13");
            product.WhenUserSelectNeededProductOnPage("Apple iPhone 13");
            product.WhenUserAddedProductInList();
            product.WhenUserOpenBookmarksMenu();
            product.ThenVerifyThatProductNameInBookmarksMenuEqualsToActualProductNameForMobileDevices();
        }
    }
}
