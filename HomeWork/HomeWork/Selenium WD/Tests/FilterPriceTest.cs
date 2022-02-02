using HomeWork.Selenium_WD.Base;
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
            var product = driver.GetPage<ProductSteps>();

            product.WhenUserEntryIntoCategoryByName("Гаджеты", "Мобильные");
            product.WhenUserSelectBrandByFilter("Apple");
            product.ThenVerifyCheckboxIsSelected("Apple");
            product.WhenUserClickOnShowFilterButton();
            product.WhenUserClickOnLinkedText("Apple iPhone 13 Pro");
            product.WhenUserClickOnLinkedText("Cравнить цены");
            product.ThenVerifyDescendingPriceSorting();
        }
    }
}
