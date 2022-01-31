using System.Collections.Generic;
using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class NameProductsViewed : BaseComponent
    {
        public override By Construct()
        {
            var selector = ".//u[@class='nobr']";
            return By.XPath(selector);
        }

        public IList<IWebElement> ListNameProductsViewe()
        {
            var nameProducts = Driver.FindElements(Construct());
            return nameProducts;
        }
    }
}
