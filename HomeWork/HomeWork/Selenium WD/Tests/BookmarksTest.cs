using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    internal class BookmarksTest : BaseTest
    {

        [Test]
        public void TestBookmarks()
        {
            var product = driver.GetPage<ProductSteps>();
            product.WhenUserEntryIntoCategoryByName("Гаджеты", "Мобильные");
            product.WhenUserSelectBrandByFilter("Apple");
            product.ThenVerifyCheckboxIsSelected("Apple");
            product.WhenUserClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Apple iPhone 13");
            product.WhenUserSelectNeededProductOnPage("Apple iPhone 13");
            product.WhenUserAddedProductInList();
            product.WhenUserOpenBookmarksMenu();
            product.ThenVerifyThatProductNameInBookmarksMenuEqualsToActualProductNameForMobileDevices();
        }
    }
}
