using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Functional;
using NUnit.Framework;

namespace HomeWork
{
    internal class SearchFieldTest : BaseTest
    {

        [Test]
        public void TestSearchField()
        {
            var searchField = driver.GetPage<SearchField>();
            
            searchField.SearchFieldProductInput("iPhone 13 Pro 256");
            searchField.VerifyItemForSeraching("iPhone 13 Pro 256");
        }
    }
}
