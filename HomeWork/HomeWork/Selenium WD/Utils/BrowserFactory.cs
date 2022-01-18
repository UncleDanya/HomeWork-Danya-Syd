using HomeWork.Selenium_WD.Providers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace HomeWork.Selenium_WD.Functional
{
    public class BrowserFactory
    {
        public static IWebDriver CreateDriver()
        {
            switch (BrowserProvider.Browser)
            {
                case "chrome":
                    var chromeDriver = new ChromeDriver();
                    return chromeDriver;

                case "firefox":
                    var _driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
                    return _driver;

                default:
                    throw new Exception("Browser from appsetting not equals to any from available");
            }
        }
    }
}
