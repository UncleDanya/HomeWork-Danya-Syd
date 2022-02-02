using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    internal class FilterTest : BaseTest
    {

        [Test]
        public void TestFilter()
        {
            var product = driver.GetPage<ProductSteps>();

            product.WhenUserEntryIntoCategoryByName("Компьютеры", "Ноутбуки");
            product.WhenUserSelectBrandByFilter("Acer");
            product.ThenVerifyFilterCheckboxIsSelected("Acer");
            product.WhenUserClickOnLinkedText("Показать");
            product.ThenVerifyFilterShowActualBrand("Acer");
        }
    }
}
