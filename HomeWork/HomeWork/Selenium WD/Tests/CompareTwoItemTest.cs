using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using System.Threading;
using HomeWork.Selenium_WD.Extensions;

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
            
            category.EntryIntoCategoryByName("Компьютеры", "Планшеты");
            
            categoryPage.SearchBrandByFilter("Apple");
            categoryPage.VerifyThatCheckboxIsSelected("Apple");
            categoryPage.ClickOnShowFilterButton();
            
            productPages.SelectProductOnPage("Apple iPad").Click();
            var nameFirstTablet = productPages.FooterWithNameOnPage.Text;
            productPages.AddedToCompareCheckboxProduct.Click();
            
            Thread.Sleep(1000);
            
            var attribute = productPages.SwitchToPageWithTablet.GetAttribute("link");
            productPages.SwitchToPageWithTablet.Click();
            productPages.SelectProductOnPage("Apple iPad Air").Click();
            var nameSecondTablet = productPages.FooterWithNameOnPage.Text;
            productPages.AddedToCompareCheckboxProduct.Click();
            
            Thread.Sleep(2000);
            
            productPages.SwitchToComparePage.Click();

            var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);

            var nameFirstTabletInComparePage = compareProduct.NameProductForCompare("Apple iPad 2021").Text;
            var nameSecondTabletInComparePage = compareProduct.NameProductForCompare("Apple iPad Air").Text;

            Assert.IsTrue(nameFirstTabletInComparePage.Contains(nameFirstTablet), "The added item does not match the item on the list");
            Assert.IsTrue(nameSecondTabletInComparePage.Contains(nameSecondTablet), "The added item does not match the item on the list");
            Assert.AreEqual(attribute, "/list/30/apple/");
        }
    }
}
