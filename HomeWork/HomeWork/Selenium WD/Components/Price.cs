using System.Collections.Generic;
using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class Price : BaseComponent
    {
        public override By Construct()
        {
            var selector = ".//b[text()]//parent::a";
            return By.XPath(selector);
        }

        public IList<IWebElement> ListPrice()
        {
            var priceList = Instance.FindElements(Construct());
            return priceList;
        }
    }
}
