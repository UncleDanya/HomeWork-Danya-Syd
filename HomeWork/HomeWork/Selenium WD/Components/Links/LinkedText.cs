using System.Collections.Generic;
using HomeWork.Selenium_WD.Components.Utils;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Links
{
    class LinkedText : BaseComponent
    {
        
        public override By Construct()
        {
            var selector = $".//*[text()='{Identifier}']//ancestor::a[@href]";
            return By.XPath(selector);
        }
        //a[@href and text()='{Identifier}']
        public IWebElement ForCompareNameProducts(string nameProduct)
        {
            var name = Driver.FindElement(
                By.XPath($".//table[@id='compare_table']//child::a[contains(text(),'{nameProduct}')]"));
            return name;
        }

        public IList<IWebElement> ListName()
        {
            var nameList = Driver.FindElements(Construct());
            return nameList;
        }

        public IList<IWebElement> ListContainsName(string name)
        {
            WaitUtils.WaitForElementToBeClickable(Driver, Instance);
            var nameContainsList =
                Driver.FindElements(
                    By.XPath($".//form[@id='list_form1']//*[contains(text(),'{name}')]//ancestor::a[@href]"));
            return nameContainsList;
        }

        public void Click()
        {
            WaitUtils.WaitForElementToBeClickable(Driver, Instance);
            Instance.Click();
        }
    }
}
