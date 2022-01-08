using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageHeadsetProductLogitech : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//span[@class='u' and text()]")]
        public IList<IWebElement> NameAllProductInPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Сохранить список']")]
        public IWebElement SaveListProductButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement SubmitSaveProductListButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='u' and text()='Logitech G Pro X']")]
        public IWebElement NameProductOnHeadsetPage { get; set; }
    }
}
