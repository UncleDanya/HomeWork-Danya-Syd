using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Selenium_WD.Pages
{
    internal class UserPage
    {
        private IWebDriver driver;
        
        [FindsBy(How = How.ClassName, Using = "user-menu__name")]
        public IWebElement actualNameUser { get; set; }

        [FindsBy(How = How.ClassName, Using = "user-menu__name")]
        public IWebElement textActualNameUser { get; set; }
    }
}
