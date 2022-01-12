using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;


namespace HomeWork.Selenium_WD.Functional
{
    internal class PriceSorting
    {
        private IWebDriver driver;

        public PriceSorting(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void DescendingPriceFilter()
        {
            var lastPage = driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allPrice = driver.FindElements(By.XPath("//b[text()]//parent::a"));

                for (int j = 0; j < allPrice.Count - 1; j++)
                {
                    var priceWithoutText = Convert.ToInt32(allPrice[j].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    var nextPriceWithoutText = Convert.ToInt32(allPrice[j + 1].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    
                    Assert.IsTrue(priceWithoutText <= nextPriceWithoutText, "Prices are not consistent");
                }

                try
                {
                    var nextPageButton = driver.FindElement(By.XPath("//a[@id='pager_next']"));
                    nextPageButton.Click();
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
