namespace E2EGiacomTestAutomation.Utilities.Helpers.TestDataGenerator.BaseGenerators
{
    using Faker;

    public class AddressGenerator
    {
        public string City => Address.City();

        public string CityPrefix => Address.CityPrefix();

        public string CitySuffix => Address.CitySuffix();

        public string Country => Address.Country();

        public string SecondaryAddress => Address.SecondaryAddress();

        public string StreetAddress => Address.StreetAddress();

        public string StreetAddressIncludingSecondary => Address.StreetAddress(includeSecondary: true);

        public string StreetName => Address.StreetName();

        public string StreetSuffix => Address.StreetSuffix();

        public string UkCountry => Address.UkCountry();

        public string UkCounty => Address.UkCounty();

        public string UkPostCode => Address.UkPostCode();

        public string UsState => Address.UsState();

        public string UsStateAbbr => Address.UsStateAbbr();

        public string ZipCode => Address.ZipCode();
    }
}
