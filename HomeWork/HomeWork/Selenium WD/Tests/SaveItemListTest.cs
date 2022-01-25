using HomeWork.Selenium_WD.Base;
using NUnit.Framework;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;

namespace HomeWork
{
    internal class SaveItemListTest : BaseTest
    {

        [Test]
        public void TestSaveItemList()
        {
            var product = driver.GetPage<ProductSteps>();
            var user = driver.GetPage<UserSteps>();

            user.WhenUserCreateNewUserAccount();
            product.WhenUserEntryIntoCategoryByName("Аудио", "Наушники");
            product.WhenUserSelectBrandByFilter("Logitech");
            product.ThenVerifyCheckboxIsSelected("Logitech");
            product.WhenUserClickOnShowFilterButton();
            product.WhenUserSaveAllProductOnPageInList();
            product.WhenUserClickOnSaveItemInList();
            product.WhenUserClickOnSubmitSaveListButton();
            product.WhenUserSwitchToUserPage();
            user.WhenUserClickOnButtonShowSaveProductList();
            product.ThenVerifyListSaveInProductPageForListInUserPage();
        }

        [TearDown]
        public void AfterTest()
        {
            var user = driver.GetPage<UserSteps>();
            user.WhenUserDeleteUserAccount();
        }
    }
}
