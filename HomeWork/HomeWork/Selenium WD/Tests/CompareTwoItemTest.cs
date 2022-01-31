using HomeWork.Selenium_WD.Base;
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
            var product = driver.GetPage<ProductSteps>();
            
            product.WhenUserEntryIntoCategoryByName("Компьютеры", "Планшеты");
            product.WhenUserSelectBrandByFilter("Apple");
            product.ThenVerifyCheckboxIsSelected("Apple");
            product.WhenUserClickOnShowFilterButton();
            product.WhenUserRememberNameProduct("Apple iPad");
            product.WhenUserSelectNeededProductOnPage("Apple iPad");
            product.WhenUserAddedToCompareCheckboxProduct();
            product.WhenUserSwitchToPageWithTablet();
            product.WhenUserRememberNameProduct("Apple iPad Air");
            product.WhenUserSelectNeededProductOnPage("Apple iPad Air");
            product.WhenUserAddedToCompareCheckboxProduct();
            product.WhenUserSwitchToComparePage();
            product.WhenUserSwitchToSecondPage();
            product.ThenVerifyProductNameForCompareTwoItems("Apple iPad 2021", "Apple iPad Air 2020");
        }
    }
}
