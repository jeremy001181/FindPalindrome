using System;

namespace FindThePalindrome
{
    public class Palindrome : IEquatable<Palindrome>
    {
        public Palindrome(string text, int start)
        {
            Text = text;
            Start = start;
        }

        public bool IgnoreCase { get; set; }

        public bool LowestFirst { get; set; }

        public int Start { get; private set; }

        public string Text { get; }

        public override string ToString()
        {
            return $"Text: {Text}, Index: {Start}, Length: {Text.Length}";
        }
        
        public bool Equals(Palindrome other)
        {
            var ignoreCase = IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            var isDuplicate = other.Text.Equals(Text, ignoreCase);
            var isPartOfIt = Start <= other.Start && Text.Length + Start >= other.Text.Length + other.Start;

            if (isDuplicate) {
                // Smelly and hacky..
                Start = LowestFirst  && Start > other.Start ? other.Start : Start;
                Start = !LowestFirst && Start < other.Start ? other.Start : Start;
            }

            return isDuplicate || isPartOfIt;
        }
    }
}