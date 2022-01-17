using HomeWork.Selenium_WD.Providers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;


namespace HomeWork.Selenium_WD.Functional
{
    public class BrowserFactory
    {
        // RemoteWebDriver driver;
        public static RemoteWebDriver CreateDriver()
        {
            switch(BrowserProvider.Browser) {
                case "chrome":
                    // driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--safebrowsing-disable-download-protection");
                    var driver = new ChromeDriver("C:\\Users\\Danya\\source\\repos\\HomeWork-Danya-Syd\\HomeWork\\HomeWork\\bin\\Debug\\net6.0\\chromedriver.exe", chromeOptions);
                    return driver;

                case "firefox":
                    var _driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
                    return _driver;

                default:
                    throw new Exception("Browser from appsetting not equals to any from avaible");
            }
        }
    }
}
