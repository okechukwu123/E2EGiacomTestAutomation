namespace E2EGiacomTestAutomation.Configuration.TestConfigurationSection
{
    using System.Configuration;
    using Utilities.Enums;

    public class TestConfigurationSection : ConfigurationSection
    {
        public static readonly TestConfigurationSection SectionDetails = ConfigurationManager.GetSection("testConfiguration") as TestConfigurationSection;

        [ConfigurationProperty("browser", IsRequired = true, DefaultValue = BrowserType.Chrome)]
        public BrowserType Browser
        {
            get { return (BrowserType)this["browser"]; }
        }

        [ConfigurationProperty("waitTimeout", IsRequired = true, DefaultValue = "30")]
        public int WaitTimeout
        {
            get { return (int)this["waitTimeout"]; }
        }

        [ConfigurationProperty("screenshotDirectory", IsRequired = false)]
        public string ScreenshotDirectory
        {
            get { return (string)this["screenshotDirectory"]; }
        }

        [ConfigurationProperty("pages")]
        [ConfigurationCollection(typeof(PageConfiguration), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public Pages Pages
        {
            get { return (Pages)this["pages"]; }
        }
    }
}
