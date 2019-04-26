namespace PigLatin
{
    using System;
    using System.Linq;

    public static class CharExtensions
    {
        public static bool IsNotLatinLetter(this char c) => !IsLatinLetter(c);

        public static bool IsLatinLetter(this char c) => IsSmallLatinLetter(c) || IsCapitalLatinLetter(c);

        public static bool IsCapitalLatinLetter(this char c) => c >= 'A' && c <= 'Z';

        public static bool IsSmallLatinLetter(this char c) => c >= 'a' && c <= 'z';

        public static bool IsVowel(this char c) => "aeiou".IndexOf(c.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0;

        public static bool IsWordSeparator(this char c) => WordSeparators.Chars.Contains(c);

        /// <summary>
        /// As there's no list of possible punctuation characters,
        /// and we presume that the original text is in English,
        /// we can assume that every character that is not a letter
        /// nor word separator is a punctuation character.
        /// </summary>
        /// <param name="c">A character</param>
        /// <returns>True if the character is considered a punctuation, false otherwise</returns>
        public static bool IsPunctuation(this char c) => !(c.IsLatinLetter() || c.IsWordSeparator());
    }
}
