using System.Collections.Generic;
using HomeWork.Selenium_WD.Components.Utils;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class NameProduct : BaseComponent
    {
        public override By Construct()
        {
            var selector = "//span[@class='u' and text()]";
            return By.XPath(selector);
        }

        public IList<IWebElement> ListNameProducts()
        {
            WaitUtils.WaitForElementToBeClickable(Driver, Instance);
            var nameContainsList = Driver.FindElements(Construct());
            return nameContainsList;
        }
    }
}
