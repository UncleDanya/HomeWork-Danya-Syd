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
            product.ThenVerifyFilterCheckboxIsSelected("Apple");
            product.WhenUserClickOnLinkedText("Показать");
            product.WhenUserRememberNameProduct("Apple iPad");
            product.WhenUserClickOnLinkedText("Apple iPad");
            product.WhenUserClickOnCheckbox("добавить в сравнение");
            product.WhenUserClickOnLinkedText("Apple");
            product.WhenUserRememberNameProduct("Apple iPad Air");
            product.WhenUserClickOnLinkedText("Apple iPad Air");
            product.WhenUserClickOnCheckbox("добавить в сравнение");
            product.WhenUserSwitchToBottomBarMenuPage("Сравнить");
            product.WhenUserSwitchToSecondPage();
            product.ThenVerifyProductNameForCompareTwoItems("Apple iPad 2021", "Apple iPad Air 2020");
        }
    }
}
