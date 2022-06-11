namespace E2EGiacomTestAutomation.Pages.CommonPage
{
    using System;
    using OpenQA.Selenium;
    using E2EGiacomTestAutomation.Utilities;
    using Utilities.Extensions;

    public partial class CommonPage
    {
        public void ClosePrivacyNote()
        {
            try
            {
                TimeSpan originalTimeout = SeleniumExecutor.Driver.Manage().Timeouts().ImplicitWait;
                SeleniumExecutor.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
                this.PrivacyPolicyCloseButton.Click();
                SeleniumExecutor.Driver.Manage().Timeouts().ImplicitWait = originalTimeout;
            }
            catch (NoSuchElementException) { }
        }
    }
}
