﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;
using System.Threading;

namespace HomeWork.Selenium_WD.Functional
{
    internal class PriceSorting
    {
        private RemoteWebDriver driver;

        public PriceSorting(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        public void VerifyDescendingPriceSorting()
        {
            driver.FindElement(By.XPath(".//a[@jtype='click' and text()='по цене']")).Click();
            
            Thread.Sleep(1000);
            
            var lastPage = driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allPrice = driver.FindElements(By.XPath("//b[text()]//parent::a"));

                for (int j = 0; j < allPrice.Count - 1; j++)
                {
                    var priceWithoutText = Convert.ToInt32(allPrice[j].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    var nextPriceWithoutText = Convert.ToInt32(allPrice[j + 1].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    
                    Assert.IsTrue(priceWithoutText <= nextPriceWithoutText, "Prices are not consistent");
                }

                try
                {
                    var nextPageButton = driver.FindElement(By.XPath("//a[@id='pager_next']"));
                    nextPageButton.Click();
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
