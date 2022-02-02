using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    internal class ViewedProductsTest : BaseTest
    {

        [Test]
        public void TestViewedProducts()
        {
            var product = driver.GetPage<ProductSteps>();
            var user = driver.GetPage<UserSteps>();

            user.GivenUserCreateNewUserAccount();
            product.WhenUserEntryIntoCategoryByName("Аудио", "Наушники");
            product.WhenUserSelectBrandByFilter("Apple");
            product.ThenVerifyCheckboxIsSelected("Apple");
            product.WhenUserClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Apple AirPods Pro");
            product.WhenUserClickOnLinkedText("Apple AirPods Pro");
            product.WhenUserEntryIntoCategoryByName("Компьютеры", "Приставки");
            product.WhenUserSelectBrandByFilter("Sony");
            product.ThenVerifyCheckboxIsSelected("Sony");
            product.WhenUserClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Sony PlayStation 5");
            product.WhenUserClickOnLinkedText("Sony PlayStation 5");
            product.WhenUserEntryIntoCategoryByName("Аудио", "Наушники");
            product.WhenUserSelectBrandByFilter("Logitech");
            product.ThenVerifyCheckboxIsSelected("Logitech");
            product.WhenUserClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Logitech G Pro X");
            product.WhenUserClickOnLinkedText("Logitech G Pro X");
            product.WhenUserSwitchToUserPage();
            product.ThenVerifySaveListProductForListInUserPage();
        }

        [TearDown]
        public void AfterTest()
        {
            var user = driver.GetPage<UserSteps>();
            user.WhenUserDeleteUserAccount();
        }
    }
}
