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

            user.GivenUserCreateNewUserAccount();
            product.WhenUserEntryIntoCategoryByName("Аудио", "Наушники");
            product.WhenUserSelectBrandByFilter("Logitech");
            product.ThenVerifyFilterCheckboxIsSelected("Logitech");
            product.WhenUserClickOnLinkedText("Показать");
            product.WhenUserSaveAllProductOnPageInList();
            product.WhenUserAddedProductInList();
            product.WhenUserClickOnTypeButton("submit");
            product.WhenUserSwitchToUserPage();
            user.WhenUserClickOnTabsInUserPage("Наушники Logitech");
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
