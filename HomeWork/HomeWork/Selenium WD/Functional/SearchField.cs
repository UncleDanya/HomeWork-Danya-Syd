using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var searchingItems = driver.FindElements(By.XPath("//td[@class='where-buy-description']//h3[text()]"));

            foreach (var searchingItem in searchingItems)
            {
                var searchResultsText = searchingItem.Text;
                Assert.IsTrue(searchResultsText.Contains(productSearch));
            }
        }
    }
}
