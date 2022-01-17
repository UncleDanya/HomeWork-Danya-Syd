using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Functional
{
    internal class SearchField
    {
        private IWebDriver driver;

        public SearchField(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SearchFieldProductInput(string productSearch)
        {
            var searchInput = driver.FindElement(By.XPath("//input[@id='ek-search']"));
            searchInput.SendKeys(productSearch);

            var searchButton = driver.FindElement(By.Name("search_but_"));
            searchButton.Click();
        }

        public void VerifyItemForSeraching(string nameItem)
        {
            var searchingItems = driver.FindElements(By.XPath("//td[@class='where-buy-description']//h3[text()]"));

            foreach (var searchingItem in searchingItems)
            {
                var searchResultsText = searchingItem.Text;

                Assert.IsTrue(searchResultsText.Contains(nameItem));
            }
        }
    }
}
