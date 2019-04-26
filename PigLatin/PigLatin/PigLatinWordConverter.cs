namespace PigLatin
{
    using System;
    using System.Linq;

    public static class PigLatinWordConverter
    {
        public const string UnmodifiableEnding = "way";

        public static string Convert(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return word;
            }

            if (word.Any(CharExtensions.IsWordSeparator))
            {
                throw new ArgumentException(nameof(word));
            }
            
            if (word.EndsWith(UnmodifiableEnding, StringComparison.OrdinalIgnoreCase))
            {
                return word;
            }

            var capitalization = new WordCapitalization(word);
            var punctuation = new WordPunctuation(capitalization.LowerCaseWord);

            var convertedWord = punctuation.WordWithoutPunctuation;

            if (convertedWord[0].IsVowel())
            {
                convertedWord += "way";
            }
            else
            {
                var consonant = convertedWord[0];
                convertedWord = convertedWord.Remove(0, 1) + consonant + "ay";
            }

            return punctuation.Apply(capitalization.Apply(convertedWord));
        }
    }
}
