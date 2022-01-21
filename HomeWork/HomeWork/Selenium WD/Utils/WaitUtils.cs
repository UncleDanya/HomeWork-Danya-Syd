using System;
using AutomationUtils.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HomeWork.Selenium_WD.Utils
{
    public static class WaitUtils
    {
        public static IWebElement WaitForElementToBeDisplayed(IWebDriver driver, IWebElement element, 
            WebDriverExtensions.WaitTime waitTime = WebDriverExtensions.WaitTime.Short)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds((int)waitTime));
            wait.Until(waitForElement =>
            {
                if (element.Displayed)
                {
                    return element;
                }

                return null;
            });
            return element;
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, IWebElement element,
            WebDriverExtensions.WaitTime waitTime = WebDriverExtensions.WaitTime.Long)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds((int) waitTime));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForAllElementsInListIsVisible(IWebDriver driver, By elements,
            WebDriverExtensions.WaitTime waitTime = WebDriverExtensions.WaitTime.Short)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds((int) waitTime));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
        }

        public static void WaitForAlertIsPresent(IWebDriver driver,
            WebDriverExtensions.WaitTime waitTime = WebDriverExtensions.WaitTime.Short)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public static void WaitForElementToBeSelected(IWebDriver driver, IWebElement element,
            WebDriverExtensions.WaitTime waitTime = WebDriverExtensions.WaitTime.Short)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeSelected(element));
        }
    }
}
