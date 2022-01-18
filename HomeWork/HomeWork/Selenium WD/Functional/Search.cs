using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Functional
{
    internal class SearchField : BasePage
    {
        public void SearchFieldProductInput(string productSearch)
        {
            var searchInput = Driver.FindElement(By.XPath("//input[@id='ek-search']"));
            searchInput.SendKeys(productSearch);

            var searchButton = Driver.FindElement(By.Name("search_but_"));
            searchButton.Click();
        }

        public void VerifyItemForSeraching(string nameItem)
        {
            var searchingItems = Driver.FindElements(By.XPath("//td[@class='where-buy-description']//h3[text()]"));

            foreach (var searchingItem in searchingItems)
            {
                var searchResultsText = searchingItem.Text;

                Assert.IsTrue(searchResultsText.Contains(nameItem));
            }
        }
    }
}
