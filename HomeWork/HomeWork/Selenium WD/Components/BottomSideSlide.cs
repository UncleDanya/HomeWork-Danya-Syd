using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class BottomSideSlide : BaseComponent
    {
        public override By Construct()
        {
            var selecror = ".//div[@id='content_bm_marked']";
            return By.XPath(selecror);
        }

        public IWebElement TextProductInSlide()
        {
            // Thread.Sleep(3000);
            // WaitUtils.WaitForElementToBeClickable(Driver, Instance);
            var nameProduct = Driver.FindElement(By.XPath(".//a[@class='touchcarousel-item side-list-block block-selected ']//child::div[@class='panel-item-close']//following-sibling::div[@class='side-list-label ' and text()]"));
            // WaitUtils.WaitForElementToBeClickable(Driver, nameProduct);
            return nameProduct;
        }
    }
}
