using System;
using System.Linq;

namespace HomeWork
{
    internal class RandomUser
    {
        public string CreateRandomLogin()
        {
            Random randomUs = new Random();
            String b = "qwertyuiopasdfghjklzxcvbnm";
            int lenght = 6;
            String random = string.Empty;

            for (int i = 0; i < lenght; i++)
            {
                int a = randomUs.Next(26);
                random = random + b.ElementAt(a);
            }
            return random;
        }

        public string CreateRandomPassword()
        {
            Random random = new Random();
            String str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 8;
            String randomstring = string.Empty;

            for (int i = 0; i < size; i++)
            {
                int x = random.Next(str.Length);
                randomstring = randomstring + str[x];
            }
            return randomstring;
        }

        public string CreateRandomEmail()
        {
            Random user = new Random();
            String b = "qwertyuiopasdfghjklzxcvbnm";
            int lenght = 6;
            String random = string.Empty;

            for (int i = 0; i < lenght; i++)
            {
                int a = user.Next(26);
                random = random + b.ElementAt(a);
            }
            random += "@gmail.com";
            return random;
        }
    }
}
