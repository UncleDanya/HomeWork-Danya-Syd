using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Selenium_WD.Pages
{
    internal class UserPage : BasePage
    {
        
        [FindsBy(How = How.ClassName, Using = "info-nick")]
        public IWebElement ActualNameUser { get; set; }

        [FindsBy(How = How.ClassName, Using = "user-menu__name")]
        public IWebElement TextActualNameUser { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='user-menu__edit' and @title='Редактировать']")]
        public IWebElement EditProfileButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='ek-form-control' and @name='p_[NikName]']")]
        public IWebElement NikFieldInputButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ek-form-btn blue' and text()='СОХРАНИТЬ']")]
        public IWebElement SaveChangeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='user-menu__section wu_bookmarks ']")]
        public IWebElement ShowSaveProductList { get; set; }
    }
}
