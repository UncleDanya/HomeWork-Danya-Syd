using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageTabletAppleiPadAir2020 : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//label[@id='label_1870142']")]
        public IWebElement AddedToCompareButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='num_bm_compared']")]
        public IWebElement SwitchToComparePage { get; set; }
    }
}
