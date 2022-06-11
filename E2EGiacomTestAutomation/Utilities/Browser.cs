namespace E2EGiacomTestAutomation.Utilities
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using E2EGiacomTestAutomation.Pages.CommonPage;
    using E2EGiacomTestAutomation.Utilities.Enums;
    using E2EGiacomTestAutomation.Utilities.Extensions;
    using E2EGiacomTestAutomation.Utilities.Helpers;
    using configs = Configuration.TestConfigurationSection.TestConfigurationSection;


    public static class Browser
    {
        public static void GoTo(Pages page, string path = "", string queryString = "")
        {
            CommonPage commonPage = new CommonPage();

            if (!SeleniumExecutor.Pages.ContainsKey(page))
            {
                throw new InvalidOperationException($"The specified page ({page}) can not be found in the configuration");
            }

            var targetUrl = $"{SeleniumExecutor.Pages[page].AbsoluteUri}{path}{queryString}";

            try
            {
                SeleniumExecutor.Driver.Url = targetUrl;
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Webdriver could not reach specified URL within timeout limit. \n Target URL: {targetUrl} \n Actual URL: {SeleniumExecutor.Driver.Url} \n", e);
            }
        }

        public static void RefreshPage()
        {
            SeleniumExecutor.Driver.Navigate().Refresh();
        }

        public static void DeleteCookies()
        {
            SeleniumExecutor.Driver.Manage().Cookies.DeleteAllCookies();
        }

        public static void SwitchToWindowHandle(int window)
        {
            var windowHandles = GetWindowHandles();
            SeleniumExecutor.Driver.SwitchTo().Window(windowHandles[window]);
        }

        public static IAlert SwitchToAlert()
        {
            return SeleniumExecutor.Driver.SwitchTo().Alert();
        }

        public static ReadOnlyCollection<string> GetWindowHandles()
        {
            return SeleniumExecutor.Driver.WindowHandles;
        }

        public static void CloseTab()
        {
            SeleniumExecutor.Driver.Close();
        }
        public static void ResizeToFullScreen()
        {
            SeleniumExecutor.Driver.Manage().Window.FullScreen();
        }

        private static bool IsAlertPresent()
        {
            try
            {
                SwitchToAlert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
            catch (NoSuchWindowException)
            {
                return false;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
    }
}
