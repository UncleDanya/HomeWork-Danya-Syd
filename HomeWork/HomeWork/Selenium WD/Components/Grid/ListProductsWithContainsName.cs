using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Grid
{
    class ListProductsWithContainsName : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//form[@id='list_form1']//*[contains(text(),'{Identifier}')]//ancestor::a[@href]";
            return By.XPath(selector);
        }
    }
}
