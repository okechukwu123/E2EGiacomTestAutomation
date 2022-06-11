namespace E2EGiacomTestAutomation.Tests.Steps
{
    using FluentAssertions;
    using E2EGiacomTestAutomation.Pages.CommonPage;
    using E2EGiacomTestAutomation.Utilities;
    using E2EGiacomTestAutomation.Utilities.Extensions;
    using TechTalk.SpecFlow;

    [Binding]
    public class CommonSteps
    {
        private CommonPage commonPage = new CommonPage();

        [Then(@"I can see expected page ""(.*)""")]
        public void ThenICanSeeExpectedPage(string pageTitle)
        {
            this.commonPage.PageTitle(pageTitle).IsDisplayedAfterWait().Should().BeTrue();
        }

        [Then(@"I can see expected page ""(.*)"" in a new tab")]
        public void ThenICanSeeExpectedPageInNewTab(string pageTitle)
        {
            Browser.SwitchToWindowHandle(SeleniumExecutor.Driver.WindowHandles.Count - 1);
            try
            {
                this.commonPage.PageHeader(pageTitle).IsDisplayedAfterWait().Should().BeTrue();
            }
            finally
            {
                Browser.CloseTab();
                Browser.SwitchToWindowHandle(0);
                Browser.ResizeToFullScreen();
            }
        }
    }
}