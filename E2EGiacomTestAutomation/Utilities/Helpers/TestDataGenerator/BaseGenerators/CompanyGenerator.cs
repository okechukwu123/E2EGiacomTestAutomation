namespace E2EGiacomTestAutomation.Utilities.Helpers.TestDataGenerator.BaseGenerators
{
    using Faker;

    public class CompanyGenerator
    {
        public string BS => Company.BS();

        public string CatchPhrase => Company.CatchPhrase();

        public string Name => Company.Name();

        public string Suffix => Company.Suffix();
    }
}
