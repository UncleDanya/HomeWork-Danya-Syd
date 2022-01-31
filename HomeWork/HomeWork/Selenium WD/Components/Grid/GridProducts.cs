using System.Collections.Generic;
using HomeWork.Selenium_WD.Components.Utils;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Grid
{
    class GridProducts : BaseComponent
    {
        public override By Construct()
        {
            var selector = ".//form[@id='list_form1']";
            return By.XPath(selector);
        }

        public IList<IWebElement> ListProducts(string name)
        {
            WaitUtils.WaitForElementToBeClickable(Driver, Instance);
            var nameContainsList =
                Driver.FindElements(
                    By.XPath($".//form[@id='list_form1']//*[contains(text(),'{name}')]//ancestor::a[@href]"));
            return nameContainsList;
        }

        public IList<IWebElement> ListNameProdcuts()
        {
            WaitUtils.WaitForElementToBeClickable(Driver, Instance);
            var nameContainsList =
                Driver.FindElements(
                    By.XPath(".//form[@id='list_form1']//span[@class='u' and text()]"));
            return nameContainsList;
        }
    }
}
