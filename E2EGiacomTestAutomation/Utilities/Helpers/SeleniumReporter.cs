namespace E2EGiacomTestAutomation.Utilities.Helpers
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Configuration.TestConfigurationSection;
    using OpenQA.Selenium;

    public static class SeleniumReporter
    {
        public static void TakeScreenshot(string testName)
        {
            try
            {
                ITakesScreenshot tsdriver = SeleniumExecutor.Driver as ITakesScreenshot;
                Screenshot image = tsdriver.GetScreenshot();
                string path = GetScreenshotFullPath(testName);
                DeleteScreenshotIfExist(path);
                image.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void DeleteScreenshotIfExist(string pathWithFileName)
        {
            try
            {
                if (File.Exists(pathWithFileName))
                {
                    File.Delete(pathWithFileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static string GetScreenshotFullPath(string name)
        {
            string execDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return $"{execDirectory}{Path.DirectorySeparatorChar}{Regex.Replace(name, @"[^\w]", "")}.jpg";
        }
    }
}
