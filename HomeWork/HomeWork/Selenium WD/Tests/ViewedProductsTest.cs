using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    internal class ViewedProductsTest : BaseTest
    {

        [Test]
        public void TestViewedProducts()
        {
            var category = driver.GetPage<ProductCategoryNavigation>();
            var categoryPage = driver.GetPage<CategoryPage>();
            var mainPage = driver.GetPage<MainPage>();
            var product = driver.GetPage<ProductSteps>();

            mainPage.CreateNewUserAccount();
            category.EntryIntoCategoryByName("Аудио", "Наушники");
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Apple AirPods Pro");
            product.WhenUserSelectNeededProductOnPage("Apple AirPods Pro");
            category.EntryIntoCategoryByName("Компьютеры", "Приставки");
            categoryPage.SearchBrandByFilter("Sony");
            categoryPage.VerifyThatCheckboxIsSelected("Sony");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Sony PlayStation 5");
            product.WhenUserSelectNeededProductOnPage("Sony PlayStation 5");
            category.EntryIntoCategoryByName("Аудио", "Наушники");
            categoryPage.SearchBrandByFilter("Logitech");
            categoryPage.VerifyThatCheckboxIsSelected("Logitech");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Logitech G Pro X");
            product.WhenUserSelectNeededProductOnPage("Logitech G Pro X");
            product.WhenUserSwitchToUserPage();
            product.ThenVerifySaveListProductForListInUserPage();
        }

        [TearDown]
        public void AfterTest()
        {
            var userPage = driver.GetPage<UserPage>();
            userPage.DeleteUserAccount();
        }
    }
}
