using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;

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
            var product = driver.GetPage<ProductSteps>();

            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserSelectNeededProductOnPage("Apple iPhone 13 Pro");
            product.WhenUserShowAllPriceOnProductButton();
            
            priceSortByDescendingPrice.VerifyDescendingPriceSorting();
        }
    }
}
