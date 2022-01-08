using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageTabletProductApple : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@data-url='/APPLE-IPAD-2021-64GB.htm']")]
        public IWebElement FirstTabletToCompare { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-url='/APPLE-IPAD-AIR-2020-64GB.htm']")]
        public IWebElement SecondTabletToCompate { get; set; }
    }
}
