using System.Collections.Generic;
using HomeWork.Selenium_WD.Components.Utils;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Grid
{
    class GridWhereBuyPorducts : BaseComponent
    {
        /*[FindsBy(How = How.XPath, Using = "//b//parent::a")]
        public string PriceOnPage { get; set; }*/
        protected const string priceOnPage = "//b//parent::a";
        public override By Construct()
        {
            var selector = ".//table[@class='where-buy-table ']";
            return By.XPath(selector);
        }

        public IList<IWebElement> PriceList()
        {
            // var listPrice = Instance.FindElements(By.XPath($"{Instance}//b//parent::a"));
            var listPrice = Instance.FindElements(By.XPath($"{priceOnPage}"));
            return listPrice;
        }

        public void Waiter()
        {
            WaitUtils.WaitForAllElementsInListIsVisible(Driver, By.XPath("//b[text()]//parent::a"));
        }
    }
}
