namespace E2EGiacomTestAutomation.Utilities.Helpers.TestDataGenerator.BaseGenerators
{
    public class NumberGenerator
    {
        public int RandomNumber() => Faker.RandomNumber.Next();

        public int RandomNumber(int max) => Faker.RandomNumber.Next(max);

        public int RandomNumber(int min, int max) => Faker.RandomNumber.Next(min, max);
    }
}
