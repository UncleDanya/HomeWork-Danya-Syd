using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutomationUtils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Org.BouncyCastle.Asn1.Cmp;
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
            WebDriverExtensions.WaitTime waitTime = WebDriverExtensions.WaitTime.Short)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds((int) waitTime));
            // wait.Until(ExpectedConditions.StalenessOf(element));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitRefresh(IWebDriver driver, IList<IWebElement> elements,
            WebDriverExtensions.WaitTime waitTime = WebDriverExtensions.WaitTime.Long)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds((int) waitTime));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy((By)elements));
        }


        /*public static IWebElement WaitForElements(IWebDriver driver, IList<IWebElement> element,
            WebDriverExtensions.WaitTime waitTime = WebDriverExtensions.WaitTime.Short)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds((int)waitTime));
            wait.Until(waitForElement =>
            {
                if (element.Dis)
                {
                    return element;
                }

                return null;
            });
            return element;
        }*/
    }
}
