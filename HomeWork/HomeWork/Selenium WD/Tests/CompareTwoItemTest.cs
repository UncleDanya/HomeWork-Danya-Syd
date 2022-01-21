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
            var compareProduct = driver.GetPage<CompareProductPage>();
            var productPages = driver.GetPage<ProductPages>();
            var product = driver.GetPage<ProductSteps>();
            
            category.EntryIntoCategoryByName("Компьютеры", "Планшеты");
            
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();
            
            /*productPages.SelectProductOnPage("Apple iPad").Click();
            var nameFirstTablet = productPages.FooterWithNameOnPage.Text;*/
            product.WhenUserSelectNeededProductOnPage("Apple iPad");
            productPages.AddedToCompareCheckboxProduct.Click();
            
            WaitUtils.WaitForElementToBeClickable(driver, productPages.SwitchToPageWithTablet);
            
            //var attribute = productPages.SwitchToPageWithTablet.GetAttribute("link");
            productPages.SwitchToPageWithTablet.Click();
            /*productPages.SelectProductOnPage("Apple iPad Air").Click();
            var nameSecondTablet = productPages.FooterWithNameOnPage.Text;*/
            product.WhenUserSelectNeededProductOnPage("Apple iPad Air");
            productPages.AddedToCompareCheckboxProduct.Click();
            
            WaitUtils.WaitForElementToBeClickable(driver, productPages.SwitchToComparePage);
            
            productPages.SwitchToComparePage.Click();

            /*var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);*/
            product.WhenUserSwitchToNextPage();

            // var nameFirstTabletInComparePage = compareProduct.NameProductForCompare("Apple iPad 2021").Text;
           // var nameSecondTabletInComparePage = compareProduct.NameProductForCompare("Apple iPad Air").Text;
            product.ThenVerifyProductNameForCompareTwoItems("Apple iPad", "Apple iPad Air");
            // Assert.IsTrue(nameFirstTabletInComparePage.Contains(nameFirstTablet), "The added item does not match the item on the list");
            // Assert.IsTrue(nameSecondTabletInComparePage.Contains(nameSecondTablet), "The added item does not match the item on the list");
            //Assert.AreEqual(attribute, "/list/30/apple/");
        }
    }
}
