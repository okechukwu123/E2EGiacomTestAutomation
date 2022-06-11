namespace E2EGiacomTestAutomation.Utilities.Helpers.TestDataGenerator.BaseGenerators
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Enums;

    public abstract class RandomGeneratorBase
    {
        static RandomGeneratorBase()
        {
            Random = new Random((int)DateTime.Now.Ticks);
        }

        protected RandomGeneratorBase()
        {
            this.UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            this.LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            this.Numeric = "01234567890123456789".ToCharArray();
            this.SpecialCharacters = "$()*=!#<>$|{^}\\/%".ToCharArray();
            this.Alphabetic = this.UpperCaseLetters.Union(this.LowerCaseLetters).ToArray();
            this.Alphanumeric = this.Alphabetic.Union(this.Numeric).ToArray();
        }

        protected static Random Random { get; private set; }

        protected char[] UpperCaseLetters { get; private set; }

        protected char[] LowerCaseLetters { get; private set; }

        protected char[] Alphabetic { get; private set; }

        protected char[] Numeric { get; private set; }

        protected char[] Alphanumeric { get; private set; }

        protected char[] SpecialCharacters { get; private set; }

        protected string GenerateRandomStringOfLength(int length, CharacterType type)
        {
            var result = string.Empty;
            var characters = this.GetCharacterArrayByType(type);
            for (var i = 0; i < length; i++)
            {
                result += characters[Random.Next(characters.Length)].ToString();
            }

            return result;
        }

        private char[] GetCharacterArrayByType(CharacterType type)
        {
            switch (type)
            {
                case CharacterType.UpperCase:
                    return this.UpperCaseLetters;
                case CharacterType.LowerCase:
                    return this.LowerCaseLetters;
                case CharacterType.Numeric:
                    return this.Numeric;
                case CharacterType.Special:
                    return this.SpecialCharacters;
                case CharacterType.Alphabetic:
                    return this.Alphabetic;
                case CharacterType.Alphanumeric:
                    return this.Alphanumeric;
                default:
                    throw new InvalidEnumArgumentException($"Invalid type in switch statement: {type.ToString()}");
            }
        }
    }
}
