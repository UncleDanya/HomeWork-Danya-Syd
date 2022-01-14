using System;
using System.Linq;

namespace HomeWork
{
    internal class RandomUser
    {
        public string CreateRandomLogin()
        {
            Random randomUs = new Random();
            String сharacters = "qwertyuiopasdfghjklzxcvbnm";
            int lenght = 2;
            String generatedUserName = "User";

            for (int i = 0; i < lenght; i++)
            {
                int randomChar = randomUs.Next(26);
                generatedUserName = generatedUserName + сharacters.ElementAt(randomChar);
            }
            return generatedUserName += randomUs.Next(1, 99);
        }

        public string CreateRandomPassword()
        {
            Random random = new Random();
            String str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 8;
            String randomstring = string.Empty;

            for (int i = 0; i < size; i++)
            {
                int randomChar = random.Next(str.Length);
                randomstring = randomstring + str[randomChar];
            }
            return randomstring;
        }

        public string CreateRandomEmail()
        {
            Random user = new Random();
            String сharacters = "qwertyuiopasdfghjklzxcvbnm";
            int lenght = 6;
            String random = string.Empty;

            for (int i = 0; i < lenght; i++)
            {
                int randomChar = user.Next(26);
                random = random + сharacters.ElementAt(randomChar);
            }
            random += "@gmail.com";
            return random;
        }
    }
}
