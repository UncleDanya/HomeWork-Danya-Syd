using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

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
            var productPages = driver.GetPage<ProductPages>();

            mainPage.CreateNewUserAccount();
            
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");

            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();

            var nameMobileProductText = productPages.SelectProductOnPage("Apple iPhone 13 Pro").Text;
            productPages.SelectProductOnPage("Apple iPhone 13 Pro").Click();
            
            category.EntryIntoCategoryByName("Компьютеры", "Приставки");

            categoryPage.SearchBrandByFilter("Sony");
            categoryPage.VerifyThatCheckboxIsSelected("Sony");
            categoryPage.ClickOnShowFilterButton();

            var nameConsoleProductText = productPages.SelectProductOnPage("Sony PlayStation 5").Text;
            productPages.SelectProductOnPage("Sony PlayStation 5").Click();
            
            category.EntryIntoCategoryByName("Аудио", "Наушники");

            categoryPage.SearchBrandByFilter("Logitech");
            categoryPage.VerifyThatCheckboxIsSelected("Logitech");
            categoryPage.ClickOnShowFilterButton();

            var nameAudioProductText = productPages.SelectProductOnPage("Logitech G Pro X").Text;
            productPages.SelectProductOnPage("Logitech G Pro X").Click();
            
            mainPage.ActualLogin.Click();
            var nameMobileItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Apple iPhone 13 Pr...']")).Text.Remove(16);
            var nameConsoleItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Sony PlayStation 5']")).Text;
            var nameAudioItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Logitech G Pro X']")).Text;

            Assert.IsTrue(nameMobileProductText.Contains(nameMobileItemInList));
            Assert.IsTrue(nameConsoleProductText.Contains(nameConsoleItemInList));
            Assert.IsTrue(nameAudioProductText.Contains(nameAudioItemInList));
        }

        [TearDown]
        public void AfterTest()
        {
            var userPage = driver.GetPage<UserPage>();
            userPage.DeleteUserAccount();
        }
    }
}
