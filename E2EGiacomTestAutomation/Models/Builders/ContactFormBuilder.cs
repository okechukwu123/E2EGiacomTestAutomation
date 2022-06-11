namespace E2EGiacomTestAutomation.Models.Builders
{
    using E2EGiacomTestAutomation.Models.Objects;
    using E2EGiacomTestAutomation.Utilities;
    using E2EGiacomTestAutomation.Utilities.Helpers.TestDataGenerator;
    using Utilities.Helpers;

    public static class ContactFormBuilder
    {
        public static ContactFormModel BuildContactFormDetails()
        {
            var testData = TestDataGenerator.GetTestData(Constants.ContactFormUser);

            return new ContactFormModel
            {
                Name = TestDataGenerator.Name.GenerateRandomFirstAndLastName(),
                Email = TestDataGenerator.Internet.EmailWithName($"{TestDataGenerator.String.AlphabeticString(10)}"),
            };
        }
    }
}
