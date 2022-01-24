using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;

namespace HomeWork
{
    internal class CompareTwoItemTest : BaseTest
    {

        [Test]
        public void TestCompareTwoItem()
        {
            var category = driver.GetPage<ProductCategoryNavigation>();
            var categoryPage = driver.GetPage<CategoryPage>();
            var product = driver.GetPage<ProductSteps>();
            
            category.EntryIntoCategoryByName("Компьютеры", "Планшеты");
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Apple iPad");
            product.WhenUserSelectNeededProductOnPage("Apple iPad");
            product.WhenUserAddedToCompareCheckboxProduct();
            product.WhenUserSwitchToPageWithTablet();
            product.WhenUserRememberNameProduct("Apple iPad Air");
            product.WhenUserSelectNeededProductOnPage("Apple iPad Air");
            product.WhenUserAddedToCompareCheckboxProduct();
            product.WhenUserSwitchToComparePage();
            product.WhenUserSwitchToSecondPage();
            product.ThenVerifyProductNameForCompareTwoItems("Apple iPad", "Apple iPad Air");
        }
    }
}
