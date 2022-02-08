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
                    var chromeDriver = new ChromeDriver("C:\\Users\\Danya\\source\\repos\\HomeWork-Danya-Syd\\HomeWork\\HomeWork\\bin\\Debug\\net5.0");
                    chromeDriver.Manage().Window.Maximize();
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
