﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }
        
        public void InitElement()
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}
