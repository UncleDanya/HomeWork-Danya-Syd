using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Grid
{
    class ProductCard : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//*[text()='{Identifier}']//ancestor::table[@class='model-short-block']";
            return By.XPath(selector);
        }
    }
}
