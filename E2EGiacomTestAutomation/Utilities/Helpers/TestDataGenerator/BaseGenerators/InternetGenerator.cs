namespace E2EGiacomTestAutomation.Utilities.Helpers.TestDataGenerator.BaseGenerators
{
    using Faker;

    public class InternetGenerator
    {
        public string DomainName => Internet.DomainName();

        public string DomainSuffix => Internet.DomainSuffix();

        public string DomainWord => Internet.DomainWord();

        public string Email => Internet.Email();

        public string FreeEmail => Internet.FreeEmail();

        public string UserName => Internet.UserName();

        public string EmailWithName(string name) => Internet.Email(name);

        public string UserNameWithName(string name) => Internet.UserName(name);
    }
}
