using HomeWork.Selenium_WD.Providers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Selenium_WD.Functional
{
    internal class BrowserFactory
    {
        public static IWebDriver CreateDriver()
        {
            switch(BrowserProvider.Browser) {
                case "chrome":
                    var driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                    return driver;

                default:
                    throw new Exception("Browser from appsetting not equals to any from avaible");
            }
        }
    }
}
