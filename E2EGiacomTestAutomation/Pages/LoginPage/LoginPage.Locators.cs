namespace E2EGiacomTestAutomation.Pages.LoginPage
{
    using OpenQA.Selenium;

    public partial class LoginPage
    {
        public By UsernameInput => By.Id("username");

        public By PasswordInput => By.Id("password");

        public By LoginButton => By.XPath("//button[contains(@class, 'radius')]");

        public By LogoutButton => By.LinkText("Logout");
    }
}