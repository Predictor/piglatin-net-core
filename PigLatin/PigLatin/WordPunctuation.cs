namespace PigLatin
{
    using System;
    using System.Collections.Generic;

    public class WordPunctuation
    {
        public WordPunctuation(string word)
        {
            var wordAndPunctuation = ExtractPunctuation(word);
            this.PunctuationPositionFromEnd = wordAndPunctuation.positions;
            this.WordWithoutPunctuation = wordAndPunctuation.word;
        }

        public IReadOnlyCollection<(int position, char letter)> PunctuationPositionFromEnd { get; }

        public string WordWithoutPunctuation { get; }

        public string Apply(string word)
        {
            var wordWithPunctuation = word ?? throw new ArgumentNullException(nameof(word));
            foreach (var (position, letter) in this.PunctuationPositionFromEnd)
            {
                wordWithPunctuation = wordWithPunctuation.Insert(wordWithPunctuation.Length - position, letter.ToString());
            }

            return wordWithPunctuation;
        }

        private static (string word, IReadOnlyCollection<(int position, char letter)> positions) ExtractPunctuation(string word)
        {
            var positions = new List<(int position, char letter)>();
            for (int i = word.Length - 1; i >= 0; i--)
            {
                if (word[i].IsPunctuation())
                {
                    positions.Add((word.Length - i - 1, word[i]));
                }
            }

            var wordWithoutPunctuation = word;
            foreach (var pos in positions)
            {
                wordWithoutPunctuation = wordWithoutPunctuation.Replace(pos.letter.ToString(), string.Empty);
            }

            return (wordWithoutPunctuation, positions);
        }
    }
}
