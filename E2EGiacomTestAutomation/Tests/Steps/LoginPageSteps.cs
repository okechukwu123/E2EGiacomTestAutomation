namespace E2EGiacomTestAutomation.Tests.Steps
{
    using FluentAssertions;
    using Pages.LoginPage;
    using E2EGiacomTestAutomation.Utilities.Extensions;
    using TechTalk.SpecFlow;
    using Utilities;
    using Utilities.Helpers.TestDataGenerator;
    using Utilities.Enums;

    [Binding]
    public class LoginPageSteps
    {
        private readonly LoginPage loginPage = new LoginPage();

        
        [When(@"I go to ""(.*)"" page")]
        public void GivenIAmOnDashboardAfterLoggingIn(Pages page)
        {
            Browser.GoTo(page);
        }

        [Given(@"I open The Internet page")]
        public void GivenIOpenLoginPage()
        {
            Browser.GoTo(Pages.Dashboard);
        }

        [When(@"I enter valid login credentials")]
        public void ThenIEnterValidLoginCredentials()
        {
            this.loginPage.Login(TestDataGenerator.GetTestData(Constants.Admin));
        }

        [Then(@"I see landing page")]
        public void ThenISeeLandingPage()
        {
            this.loginPage.PageHeader("Task to be automated").IsDisplayedAfterWait().Should().BeTrue();
            System.Console.WriteLine( "User Login");
            
        }


    }
}