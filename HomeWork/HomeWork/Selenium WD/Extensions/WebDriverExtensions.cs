
using HomeWork.Selenium_WD.Pages;
using NPOI.SS.Formula.Functions;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace HomeWork.Selenium_WD.Extensions
{
    public static class WebDriverExtensions
    {
        // public static T GetPage(this RemoteWebDriver driver) where T : BasePage, new()
        public static T GetPage<T>(this RemoteWebDriver driver) where T : BasePage, new()
        {
            var page = new T { Driver = driver };
            page.InitElement();
            return page;
        }
    }
}
