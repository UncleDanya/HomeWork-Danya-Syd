using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace HomeWork.Selenium_WD.Helpers
{
    static class JsonReader
    {
        public static string GetJsonString(string attribute)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();
            var value = config.GetSection(attribute).Value;
            return value;
        }
    }
}
