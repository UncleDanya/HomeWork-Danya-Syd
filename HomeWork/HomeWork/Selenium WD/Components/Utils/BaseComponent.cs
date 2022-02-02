using System.Collections.Generic;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Utils
{
    public class BaseComponent
    {
        public IWebDriver Driver { get; set; }
        
        public string Identifier { get; set; }
        
        public IWebElement Parent { get; set; }

        public IWebElement Instance { get; set; }

        public IList<IWebElement> Instances { get; set; }

        public virtual By Construct()
        {
            return By.XPath(Identifier);
        }

        public void Build(bool SearchValueStatus = false)
        {
            if (SearchValueStatus)
            {
                if (Parent != null)
                {
                    Instances = Parent.FindElements(Construct());
                }
                else
                {
                    WaitUtils.WaitForElementToBeDisplayed(Driver, Construct());
                    Instances = Driver.FindElements(Construct());
                }
            }
            else
            {
                if (Parent != null)
                {
                    Instance = Parent.FindElement(Construct());
                }
                else
                {
                    WaitUtils.WaitForElementToBeDisplayed(Driver, Construct());
                    Instance = Driver.FindElement(Construct());
                }
            }
        }
    }
}
