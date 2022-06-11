namespace E2EGiacomTestAutomation.Pages.CommonPage
{
    using OpenQA.Selenium;

    public partial class CommonPage
    {
        public virtual By PrivacyPolicyCloseButton => By.CssSelector(".Footer .banner_close");

        public By IEOverrideLink => By.Id("overridelink");
        
        public virtual By PageHeader(string headerText) => By.XPath($"(//*[self::h1 or self::h2 or self::h][contains(text(), '{headerText}')]|//h1[@class='page-title'][contains(text(), '{headerText}')])");
        
        public virtual By PageTitle(string titleText) => By.XPath($"(//*[@class='title']/span[contains(text(), '{titleText}')]|//*[@class='title'][contains(text(), '{titleText}')])");
    }
}