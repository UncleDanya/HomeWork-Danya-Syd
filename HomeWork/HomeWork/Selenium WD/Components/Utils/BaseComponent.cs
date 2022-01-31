using System.Collections.Generic;
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

        public void Build()
        {
            if (Parent != null)
            {
                Instance = Parent.FindElement(Construct());
            }
            else
            {
                Instance = Driver.FindElement(Construct());
            }

            Instances = Driver.FindElements(Construct());
            // Instance = Driver.FindElement(Construct());
            // Instance = Parent.FindElement(Construct());
        }
    }
}
