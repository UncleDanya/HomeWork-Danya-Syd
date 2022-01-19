using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
        public IWebElement NickFieldInputButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ek-form-btn blue' and text()='СОХРАНИТЬ']")]
        public IWebElement SaveChangeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='user-menu__section wu_bookmarks ']")]
        public IWebElement ShowSaveProductList { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='УДАЛИТЬ АККАУНТ']")]
        public IWebElement UserDeleteAdccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='УДАЛИТЬ']")]
        public IWebElement SubmitDeleteUserAccountButton { get; set; }

        public void DeleteUserAccount()
        {
            ActualNameUser.Click();
            EditProfileButton.Click();
            UserDeleteAdccountButton.Click();
            
            WaitUtils.WaitForElementToBeClickable(Driver, SubmitDeleteUserAccountButton);
            
            SubmitDeleteUserAccountButton.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            
            Driver.SwitchTo().Alert().Accept();
        }
    }
}
