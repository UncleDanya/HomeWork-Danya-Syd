﻿using HomeWork.Selenium_WD.Components.Utils;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.FolderIcon
{
    class MainCategoryDropDown : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//li[@class='mainmenu-item']/a[text()='{Identifier}']";
            return By.XPath(selector);
        }

        public void SelectCategoryFromDropdown(string pixelDropdown)
        {
            Instance.Click();
            var selector = Driver.FindElement(By.PartialLinkText($"{pixelDropdown}"));
            WaitUtils.WaitForElementToBeClickable(Driver, selector);
            selector.Click();
        }
    }
}
