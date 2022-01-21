using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;
using HomeWork.Selenium_WD.Utils;

namespace HomeWork
{
    internal class CompareTwoItemTest : BaseTest
    {

        [Test]
        public void TestCompareTwoItem()
        {
            var category = driver.GetPage<ProductCategoryNavigation>();
            var categoryPage = driver.GetPage<CategoryPage>();
            var productPages = driver.GetPage<ProductPages>();
            var product = driver.GetPage<ProductSteps>();
            
            category.EntryIntoCategoryByName("Компьютеры", "Планшеты");
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserSelectNeededProductOnPage("Apple iPad");
            productPages.AddedToCompareCheckboxProduct.Click();
            WaitUtils.WaitForElementToBeClickable(driver, productPages.SwitchToPageWithTablet);
            productPages.SwitchToPageWithTablet.Click();
            product.WhenUserSelectNeededProductOnPage("Apple iPad Air");
            productPages.AddedToCompareCheckboxProduct.Click();
            WaitUtils.WaitForElementToBeClickable(driver, productPages.SwitchToComparePage);
            productPages.SwitchToComparePage.Click();
            product.WhenUserSwitchToNextPage();
            product.ThenVerifyProductNameForCompareTwoItems("Apple iPad", "Apple iPad Air");
        }
    }
}
