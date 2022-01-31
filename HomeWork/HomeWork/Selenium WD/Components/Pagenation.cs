using System.Collections.Generic;
using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class Pagenation : BaseComponent
    {
        // ask Daniil!
        protected const string numberPage = "//a";
        public override By Construct()
        {
            var selector = ".//div[@class='ib page-num']//a";
            return By.XPath(selector);
        }

        public IList<IWebElement> ListPages()
        {
            var pagesList = Driver.FindElements(Construct());
            return pagesList;
        }
    }
}
