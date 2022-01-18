using HomeWork.Selenium_WD.Pages;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Extensions
{
    public static class WebDriverExtensions
    {
        public static T GetPage<T>(this IWebDriver driver) where T : BasePage, new()
        {
            var page = new T { Driver = driver };
            page.InitElement();
            return page;
        }
    }
}
