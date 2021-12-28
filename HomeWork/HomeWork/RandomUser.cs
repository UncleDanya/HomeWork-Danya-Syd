using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class RandomUser
    {
        public string CreateRandomLogin()
        {
            Random user = new Random();
            String b = "qwertyuiopasdfghjklzxcvbnm";
            int lenght = 6;
            String random = "";

            for (int i = 0; i < lenght; i++)
            {
                int a = user.Next(26);
                random = random + b.ElementAt(a);
            }
            return random;
        }

        public string CreateRandomPassword()
        {
            Random res = new Random();

            String str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 8;

            String randomstring = "";

            for (int i = 0; i < size; i++)
            {

                int x = res.Next(str.Length);

                randomstring = randomstring + str[x];
            }
            return randomstring;

            Console.WriteLine(randomstring);
        }

        public string CreateRandomEmail()
        {
            Random user = new Random();
            String b = "qwertyuiopasdfghjklzxcvbnm";
            int lenght = 6;
            String random = "";

            for (int i = 0; i < lenght; i++)
            {
                int a = user.Next(26);
                random = random + b.ElementAt(a);
            }
            random += "@gmail.com";
            return random;
            Console.WriteLine(random);
        }
    }
}
