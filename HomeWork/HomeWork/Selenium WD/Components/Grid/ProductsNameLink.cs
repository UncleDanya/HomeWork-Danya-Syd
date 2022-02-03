using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Grid
{
    class ProductsNameLink : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//form[@id='list_form1']//*[text()='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
