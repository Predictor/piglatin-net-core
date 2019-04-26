namespace PigLatin
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class WordCapitalization
    {
        public WordCapitalization(string word)
        {
            this.CapitalLetterPositions = GetCapitalLetterPositions(word);
            this.LowerCaseWord = word.ToLowerInvariant();
        }

        public string LowerCaseWord { get; }

        public IReadOnlyCollection<int> CapitalLetterPositions { get; }

        public string Apply(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            var builder = new StringBuilder(word);
            foreach (var position in this.CapitalLetterPositions)
            {
                if (position > word.Length - 1)
                {
                    return builder.ToString();
                }

                builder[position] = char.ToUpper(word[position]);
            }

            return builder.ToString();
        }

        private static List<int> GetCapitalLetterPositions(string word)
        {
            var positions = new List<int>();
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i].IsCapitalLatinLetter())
                {
                    positions.Add(i);
                }
            }

            return positions;
        }
    }
}