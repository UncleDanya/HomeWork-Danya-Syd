using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    public class RegistrationNewUserTest : BaseTest
    {

        [Test]
        public void TestRegistrationNewUserTest()
        {
            var user = driver.GetPage<UserSteps>();

            user.WhenUserCreateNewUserAccount();
            user.ThenVerifyAccountLoginEqualExpected();
        }

        [TearDown]
        public void AfterTest()
        {
            var user = driver.GetPage<UserSteps>();
            user.WhenUserDeleteUserAccount();
        }
    }
}