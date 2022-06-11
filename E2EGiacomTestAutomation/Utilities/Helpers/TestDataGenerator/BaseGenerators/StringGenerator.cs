namespace E2EGiacomTestAutomation.Utilities.Helpers.TestDataGenerator.BaseGenerators
{
    using System.Text;
    using Enums;
    using NLipsum.Core;

    public class StringGenerator : RandomGeneratorBase
    {
        public string AlphanumericString(int length)
        {
            return this.GenerateRandomStringOfLength(length, CharacterType.Alphanumeric);
        }

        public string AlphanumericString(int minLength, int maxLength)
        {
            var length = Random.Next(minLength, maxLength);
            return this.AlphanumericString(length);
        }

        public string AlphabeticString(int length)
        {
            return this.GenerateRandomStringOfLength(length, CharacterType.Alphabetic);
        }

        public string AlphabeticString(int minLength, int maxLength)
        {
            var length = Random.Next(minLength, maxLength);
            return this.AlphabeticString(length);
        }

        public string SpecialCharacterString(int length)
        {
            return this.GenerateRandomStringOfLength(length, CharacterType.Special);
        }

        public string SpecialCharacterString(int minLength, int maxLength)
        {
            var length = Random.Next(minLength, maxLength);
            return this.SpecialCharacterString(length);
        }

        public string RandomStringOfType(int length, CharacterType type)
        {
            return this.GenerateRandomStringOfLength(length, type);
        }

        public string RandomStringOfType(int minLength, int maxLength, CharacterType type)
        {
            var length = Random.Next(minLength, maxLength);
            return this.RandomStringOfType(length, type);
        }

        public string GetRandomSentence()
        {
            return this.GetRandomSentences(1);
        }

        public string GetRandomSentences(int howMany)
        {
            var builder = new StringBuilder();

            var sentence = new LipsumGenerator().GenerateSentences(howMany);
            foreach (string s in sentence)
            {
                builder.Append(s);
            }

            return builder.ToString();
        }
    }
}
