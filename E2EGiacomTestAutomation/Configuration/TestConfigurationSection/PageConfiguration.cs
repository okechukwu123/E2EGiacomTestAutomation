namespace E2EGiacomTestAutomation.Configuration.TestConfigurationSection
{
    using System.Configuration;

    public class PageConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public virtual Utilities.Enums.Pages Name
        {
            get
            {
                return (Utilities.Enums.Pages)this["name"];
            }

            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("path", IsRequired = true)]
        public virtual string Path
        {
            get
            {
                return (string)this["path"];
            }

            set
            {
                this["path"] = value;
            }
        }
    }
}
