namespace E2EGiacomTestAutomation.Configuration.TestDataSection
{
    using System.Configuration;
    using PGSWebsite.Configuration.TestDataSection;

    [ConfigurationCollection(typeof(TestData))]
    public class TestDataCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TestData();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TestData)element).Id;
        }
    }
}
