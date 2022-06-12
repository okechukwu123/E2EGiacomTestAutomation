namespace E2EGiacomTestAutomation.Tests.Hooks
{
    using Configuration.TestConfigurationSection;
    using E2EGiacomTestAutomation.Utilities;
    using E2EGiacomTestAutomation.Utilities.Enums;
    using E2EGiacomTestAutomation.Utilities.Helpers;
    using NUnit.Framework;
    using System.Linq;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SpecflowHooks
    {
        [BeforeScenario]
        public static void BeforeScenario()
        {
            if (TestConfigurationSection.SectionDetails.Browser == BrowserType.Chrome)
            {
                SeleniumExecutor.PrepareForDesktop();
            }
        }

        [BeforeScenario("ClearEnv")]
        public static void BeforeScenarioLogin()
        {
            Browser.DeleteCookies();
            try
            {
                SeleniumExecutor.JavaScriptExecutor.ExecuteScript("localStorage.clear();");
            }
            catch (OpenQA.Selenium.WebDriverException) { }
        }

       [AfterScenario]
        public static void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                SeleniumReporter.TakeScreenshot(TestContext.CurrentContext.Test.Name);
            }
        }

        [AfterTestRun]
        public static void CloseBrowser()
        {
            Browser.DeleteCookies();
            SeleniumExecutor.JavaScriptExecutor.ExecuteScript("localStorage.clear();");
            SeleniumExecutor.Close();
        }
    }
}
