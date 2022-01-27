
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Utils
{
    public class BaseComponent
    {
        public IWebDriver Driver { get; set; }
        
        public string Identifier { get; set; }
        
        public IWebElement Parent { get; set; }

        public IWebElement Instance { get; set; }
        

        public virtual By Construct()
        {
            return By.XPath(Identifier);
        }

        public void Build()
        {
            Instance = Driver.FindElement(Construct());
        }
    }
}
