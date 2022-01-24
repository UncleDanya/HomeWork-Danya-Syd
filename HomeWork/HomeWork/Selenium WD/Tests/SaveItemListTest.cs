using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
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
            var mainPage = driver.GetPage<MainPage>();
            var category = driver.GetPage<ProductCategoryNavigation>();
            var categoryPage = driver.GetPage<CategoryPage>();
            var product = driver.GetPage<ProductSteps>();
            var user = driver.GetPage<UserSteps>();

            mainPage.CreateNewUserAccount();
            category.EntryIntoCategoryByName("Аудио", "Наушники");
            categoryPage.SearchBrandByFilter("Logitech");
            categoryPage.VerifyThatCheckboxIsSelected("Logitech");
            categoryPage.ClickOnShowFilterButton();
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
            var userPage = driver.GetPage<UserPage>();
            userPage.DeleteUserAccount();
        }
    }
}
