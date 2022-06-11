namespace E2EGiacomTestAutomation.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Configuration.TestConfigurationSection;
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using Pages = Enums.Pages;

    public static class SeleniumExecutor
    {
        private static ChromeOptions currentChromeOptions;

        private static IWebDriver webDriver;

        private static IDictionary<Pages, Uri> pages;

        public static IWebDriver Driver => webDriver ?? (webDriver = CreateDriver());

        public static ISearchContext SearchContext => (ISearchContext)Driver;

        public static IJavaScriptExecutor JavaScriptExecutor => Driver as IJavaScriptExecutor;

        public static Actions Actions => new Actions(Driver);

        public static IDictionary<Pages, Uri> Pages => pages ?? (pages = GetPagesFromConfig());

        public static IWebDriver CreateDriver(IDictionary<string, string> customOptions = null)
        {
            IWebDriver driver = null;

            switch (TestConfigurationSection.SectionDetails.Browser)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver(GetChromeOptions (customOptions));
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver(GetFirefoxProfile());
                    break;
                case BrowserType.InternetExplorer:
                    driver = new InternetExplorerDriver(GetIEOptions());
                    break;
            }

            return ConfigureDriver(driver);
        }

        public static void Close()
        {
            if (webDriver != null)
            {
                Driver.Quit();
                webDriver = null;
            }
        }

        public static void PrepareForDesktop()
        {
            if (webDriver != null)
            {
                if (currentChromeOptions.ToString().Contains("mobileEmulation"))
                {
                    Driver.Quit();
                    webDriver = CreateDriver();
                }
            }
            else
            {
                webDriver = CreateDriver();
            }
        }

        public static WebDriverWait WaitDriver(TimeSpan? customTimeout = null)
        {
            var waitTimeout = customTimeout ?? TimeSpan.FromSeconds(TestConfigurationSection.SectionDetails.WaitTimeout);
            return new WebDriverWait(Driver, waitTimeout);
        }

        private static Dictionary<Pages, Uri> GetPagesFromConfig()
        {
            Pages baseURI = Enums.Pages.Dashboard;
            var completePagesDictionary = new Dictionary<Pages, Uri>();
            Dictionary<Pages, string> rawPagesDictionary = TestConfigurationSection.SectionDetails.Pages.OfType<PageConfiguration>()
                .ToDictionary(page => page.Name, page => page.Path);
            foreach (Pages key in rawPagesDictionary.Keys)
            {
                if (!rawPagesDictionary[key].StartsWith("http"))
                {
                    completePagesDictionary.Add(key, new Uri($"{rawPagesDictionary[baseURI]}/{rawPagesDictionary[key]}"));
                }
                else
                {
                    completePagesDictionary.Add(key, new Uri(rawPagesDictionary[key]));
                }
            }
            return completePagesDictionary;
        }

        private static ChromeOptions GetChromeOptions(IDictionary<string, string> customOptions = null)
        {
            Dictionary<string, object> chromePrefs = new Dictionary<string, object>();
            chromePrefs.Add("profile.default_content_settings.popups", 0);
            chromePrefs.Add("download.prompt_for_download", false);
            chromePrefs.Add("download.directory_upgrade", true);
            chromePrefs.Add("plugins.plugins_disabled", new string[] { "Chrome PDF Viewer" });

            ChromeOptions options = new ChromeOptions();
            options.AddLocalStatePreference("prefs", chromePrefs);
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-print-preview");
            options.AcceptInsecureCertificates = true;
            if (customOptions != null)
            {
                foreach (string key in customOptions.Keys)
                {
                    MethodInfo methodInfo = options.GetType().GetMethod(key, new[] { typeof(string) });
                    methodInfo.Invoke(options, new Object[] { customOptions[key] });
                }
            }
            currentChromeOptions = options;
            return options;
        }

        private static FirefoxOptions GetFirefoxProfile()
        {
            FirefoxOptions firefoxProfile = new FirefoxOptions();
            firefoxProfile.SetPreference("browser.download.folderList", 2);
            firefoxProfile.SetPreference("browser.download.manager.showWhenStarting", false);
            firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/vnd.ms-excel,application/pdf");
            firefoxProfile.SetPreference("pdfjs.disabled", true);
            firefoxProfile.SetPreference("plugin.scan.Acrobat", "99.0");
            firefoxProfile.SetPreference("plugin.scan.plid.all", false);
            firefoxProfile.AddAdditionalCapability("acceptInsecureCerts", true, true);

            return firefoxProfile;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions IEOptions = new InternetExplorerOptions();
            IEOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            return IEOptions;
        }

        private static IWebDriver ConfigureDriver(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            var timeout = TestConfigurationSection.SectionDetails.WaitTimeout;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);

            return driver;
        }
    }
}
