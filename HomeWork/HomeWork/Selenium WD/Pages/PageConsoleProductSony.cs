using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageConsoleProductSony : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//span[@class='u' and text()='Sony PlayStation 5']")]
        public IWebElement NameProductOnConsolePage { get; set; }
    }
}
