using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;
using HomeWork.Selenium_WD.Utils;

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
            var userPage = driver.GetPage<UserPage>();
            var productPages = driver.GetPage<ProductPages>();
            var product = driver.GetPage<ProductSteps>();

            mainPage.CreateNewUserAccount();
            category.EntryIntoCategoryByName("Аудио", "Наушники");
            categoryPage.SearchBrandByFilter("Logitech");
            categoryPage.VerifyThatCheckboxIsSelected("Logitech");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserSaveAllProductOnPageInList();
            productPages.SaveListProductOnPage.Click();
            WaitUtils.WaitForElementToBeClickable(driver, productPages.SubmitButtonSaveList);
            productPages.SubmitButtonSaveList.Click();
            WaitUtils.WaitForElementToBeClickable(driver, mainPage.EnterUserPageButton);
            mainPage.EnterUserPageButton.Click();
            userPage.ShowSaveProductList.Click();
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
