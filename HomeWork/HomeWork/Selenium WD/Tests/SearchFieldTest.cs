using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    internal class SearchFieldTest : BaseTest
    {

        [Test]
        public void TestSearchField()
        {
            var product = driver.GetPage<ProductSteps>();
            
            product.WhenUserInputNameProductInSearchField("iPhone 13 Pro", "Найти");
            product.ThenVerifyItemForSearching("iPhone 13 Pro");
        }
    }
}
