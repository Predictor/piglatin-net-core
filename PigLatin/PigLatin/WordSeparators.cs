namespace PigLatin
{
    public static class WordSeparators
    {
        public static char[] Chars => new[] { ' ', '\t', '\u000A', '\u000D', '\u0085', '\u2028', '\u2029', '\u2012', '\u2013', '\u2014', '\u2015', '\uFE58', '\uFE63', '\uFF0D', '\u002D', '\u05BE' };

        public static string[] Strings => new[] { " ", "\t", "\u000A", "\u000D", "\u000D\u000A", "\u0085", "\u2028", "\u2029", "\u2012", "\u2013", "\u2014", "\u2015", "\uFE58", "\uFE63", "\uFF0D", "\u002D", "\u05BE" };
    }
}
