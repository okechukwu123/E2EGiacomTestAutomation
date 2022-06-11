namespace E2EGiacomTestAutomation.Configuration.TestDataSection
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using PGSWebsite.Configuration.TestDataSection;

    public class TestDataSection : ConfigurationSection
    {
        public static readonly TestDataSection SectionDetails = ConfigurationManager.GetSection("testData") as TestDataSection;

        private IEnumerable<TestData> TestDataList
        {
            get
            {
                var list = new HashSet<TestData>();

                foreach (var entry in this.GetTestDataCollection())
                {
                    list.Add(entry);
                }

                if (!list.Any())
                {
                    throw new InvalidOperationException("No testData entry found in config. At least one testData entry must be specified.");
                }

                return list;
            }
        }

        [ConfigurationProperty("testDataCollection", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(TestDataCollection), AddItemName = "testData")]
        private TestDataCollection TestDataCollection
        {
            get
            {
                return (TestDataCollection)this["testDataCollection"];
            }
        }

        public TestData GetTestData(string id = "Default")
        {
            return this.TestDataList.Single(a => a.Id == id);
        }

        protected virtual IEnumerable<TestData> GetTestDataCollection()
        {
            return this.TestDataCollection.Cast<TestData>();
        }
    }
}
