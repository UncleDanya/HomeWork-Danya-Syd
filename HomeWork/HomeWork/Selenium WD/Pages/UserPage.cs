using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace HomeWork.Selenium_WD.Pages
{
    internal class UserPage : BasePage
    {
        /*private RemoteWebDriver _driver;
        public UserPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }*/
        
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
            
            Thread.Sleep(1000);
            
            SubmitDeleteUserAccountButton.Click();
            
            Thread.Sleep(1000);
            
            Driver.SwitchTo().Alert().Accept();
            
            Thread.Sleep(1000);
        }
    }
}
