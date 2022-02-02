using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.RuntimeVariables;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    internal class RenameUserTest : BaseTest
    {
        RandomLoginVariable login = new RandomLoginVariable();

        [Test]
        public void TestRenameUser()
        {
            RandomUser randomUser = new RandomUser();
            login.Value = randomUser.CreateRandomLogin();
            var user = driver.GetPage<UserSteps>();
            
            user.GivenUserCreateNewUserAccount();
            user.WhenUserClickActualLogin();
            user.WhenUserClickEditProfileButton("Редактировать");
            user.WhenUserClearFieldNickInputButton("Ваш ник");
            user.WhenUserSetTextToUserNameField("Ваш ник" , login.Value);
            user.WhenUserClickOnSaveChangeUserFieldButton("СОХРАНИТЬ");
            user.ThenVerifyActualLoginAfterRename(login.Value);
        }

        [TearDown]
        public void AfterTest()
        {
            var user = driver.GetPage<UserSteps>();
            user.WhenUserDeleteUserAccount();
        }
    }
}
