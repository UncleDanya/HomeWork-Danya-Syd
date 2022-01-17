﻿using HomeWork.Selenium_WD.Providers;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace HomeWork.Selenium_WD.Functional
{
    internal class BrowserFactory
    {
        public static RemoteWebDriver CreateDriver()
        {
            switch(BrowserProvider.Browser) {
                case "chrome":
                    var driver = new OpenQA.Selenium.Chrome.ChromeDriver();
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
