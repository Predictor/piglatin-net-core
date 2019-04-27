namespace PigLatin
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class PigLatinWordConverter
    {
        public const string Ay = "ay";
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

            // Words that end in “way” are not modified.
            if (word.EndsWith(UnmodifiableEnding, StringComparison.OrdinalIgnoreCase))
            {
                return word;
            }

            var capitalization = new WordCapitalization(word);
            var punctuation = new WordPunctuation(capitalization.LowerCaseWord);

            var convertedWord = punctuation.WordWithoutPunctuation;

            if (string.IsNullOrWhiteSpace(convertedWord))
            {
                return word;
            }

            return punctuation.Apply(capitalization.Apply(Piggify(punctuation.WordWithoutPunctuation)));
        }

        private static string Piggify(string word)
        {
            var convertedWord = word;
            if (convertedWord[0].IsVowel())
            {
                // Words that start with a vowel have the letters “way” added to the end.
                convertedWord += UnmodifiableEnding;
            }
            else
            {
                // Words that start with a consonant have their 
                // first letter moved to the end of the word and the
                // letters “ay” added to the end.
                var consonant = convertedWord[0];
                convertedWord = convertedWord.Remove(0, 1) + consonant + Ay;
            }
            return convertedWord;
        }
    }
}
