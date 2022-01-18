using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;

namespace HomeWork
{
    internal class FilterTest : BaseTest
    {

        [Test]
        public void TestFilter()
        {
            var category = driver.GetPage<ProductCategoryNavigation>();
            var categoryPage = driver.GetPage<CategoryPage>();
            var productPages = driver.GetPage<ProductPages>();

            category.EntryIntoCategoryByName("Компьютеры", "Ноутбуки");

            categoryPage.SearchBrandByFilter("Acer");
            categoryPage.VerifyThatCheckboxIsSelected("Acer");
            categoryPage.ClickOnShowFilterButton();

            productPages.VerifyFilterShowActualBrand("Acer");
        }
    }
}
