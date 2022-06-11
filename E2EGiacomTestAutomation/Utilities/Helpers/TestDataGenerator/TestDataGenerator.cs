namespace E2EGiacomTestAutomation.Utilities.Helpers.TestDataGenerator
{
    using BaseGenerators;
    using Configuration.TestDataSection;
    using PGSWebsite.Configuration.TestDataSection;
    using RandomNameGeneratorLibrary;

    public static class TestDataGenerator
    {
        /// <summary>
        /// Gets new instance of PersonNameGenerator with multiple options of generating random names and surnames
        /// </summary>
        public static PersonNameGenerator Name => new PersonNameGenerator();

        /// <summary>
        /// Gets new instance of PlaceNameGenerator with multiple options of generating random place names
        /// </summary>
        public static PlaceNameGenerator Place => new PlaceNameGenerator();

        /// <summary>
        /// Gets new instance of AddressGenerator with multiple options of generating random addresses
        /// </summary>
        public static AddressGenerator Address => new AddressGenerator();

        /// <summary>
        /// Gets random phone number
        /// </summary>
        public static string PhoneNumber => Faker.Phone.Number();

        /// <summary>
        /// Gets new instance of NumberGenerator with multiple options of generating random numbers
        /// </summary>
        public static NumberGenerator Number => new NumberGenerator();

        /// <summary>
        /// Gets new instance of InternetGenerator with multiple options of generating random emails, domains etc.
        /// </summary>
        public static InternetGenerator Internet => new InternetGenerator();

        /// <summary>
        /// Gets new instance of CompanyGenerator with multiple options of generating random company's name
        /// </summary>
        public static CompanyGenerator Company => new CompanyGenerator();

        /// <summary>
        /// Gets new instance of StringGenerator with multiple options of generating random strings
        /// </summary>
        public static StringGenerator String => new StringGenerator();

        /// <summary>
        /// Get test data stored in config file
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>TestData entry</returns>
        public static TestData GetTestData(string id = "Default")
        {
            return TestDataSection.SectionDetails.GetTestData(id);
        }
    }
}
