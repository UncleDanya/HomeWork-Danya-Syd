using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Links
{
    class LinksShop : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//u[text()='{Identifier}']";
            return By.XPath(selector);
        }
        //td[@class='model-shop-name']
        //*[text()='{Identifier}']
    }
}
