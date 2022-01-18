using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using System.Threading;
using HomeWork.Selenium_WD.Extensions;

namespace HomeWork
{
    internal class FilterPriceTest : BaseTest
    {
        
        [Test]
        public void PriceTestFilter()
        {
            var category = driver.GetPage<ProductCategoryNavigation>();
            var categoryPage = driver.GetPage<CategoryPage>();
            var priceSortByDescendingPrice = driver.GetPage<PriceSorting>();
            var productPages = driver.GetPage<ProductPages>();

            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");

            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();

            productPages.SelectProductOnPage("Apple iPhone 13 Pro").Click();
            productPages.ShowAllPriceOnProductButton.Click();

            Thread.Sleep(1000);
            
            priceSortByDescendingPrice.VerifyDescendingPriceSorting();
        }
    }
}
