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
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserSelectNeededProductOnPage("Apple iPhone 13 Pro");
            category.EntryIntoCategoryByName("Компьютеры", "Приставки");
            categoryPage.SearchBrandByFilter("Sony");
            categoryPage.VerifyThatCheckboxIsSelected("Sony");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserSelectNeededProductOnPage("Sony PlayStation 5");
            category.EntryIntoCategoryByName("Аудио", "Наушники");
            categoryPage.SearchBrandByFilter("Logitech");
            categoryPage.VerifyThatCheckboxIsSelected("Logitech");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserSelectNeededProductOnPage("Logitech G Pro X");
            mainPage.ActualLogin.Click();
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
