using HomeWork.Selenium_WD.Components.Utils;
using HomeWork.Selenium_WD.Pages;
using NPOI.POIFS.Properties;
using NPOI.SS.Formula.Functions;
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

        public static T Component<T>(this IWebDriver driver, string identifier) where T : BaseComponent, new()
        {
            T obj = new T();
            obj.Driver = driver;
            obj.Identifier = identifier;
            obj.Build();
            return obj;
        }

        public static IWebElement GetComponent<T>(this IWebDriver driver, string identifier)
            where T : BaseComponent, new()
        {
            T obj = driver.Component<T>(identifier);
            obj.Build();
            return obj.Instance;
        }
    }
}
