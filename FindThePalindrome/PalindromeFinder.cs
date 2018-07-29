using System;
using System.Collections.Generic;
using System.Linq;

namespace FindThePalindrome
{
    public class PalindromeFinder
    {
        private readonly Option option;

        public PalindromeFinder(Option option)
        {
            this.option = option ?? throw new ArgumentNullException(nameof(option));
        }

        public IEnumerable<Palindrome> FindLongestPalindrome(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (input == string.Empty)
            {
                return new[] { new Palindrome(input, 0) };
            }

            var palindromes = new UniquePalindromeList();
            // Start the cursor at the middle, then go left, right, left, right ...until touch both ends 
            for (int cursor = input.Length / 2, i = 0; i < input.Length; i++, cursor += (i % 2 == 0 ? i : -i))
            {
                palindromes.TryAdd(Verify(ref input, cursor - 1, cursor))       // Even
                           .TryAdd(Verify(ref input, cursor, cursor));          // Odd
            }

            return palindromes.OrderByDescending(p => p.Text.Length)
                              .Take(option.Count)
                              .ToList();
        }

        private Palindrome Verify(ref string input, int left, int right)
        {
            var hasFound = false;
            for (; left >= 0 && right < input.Length; left--, right++)
            {
                if (input[left] != input[right])
                    break;
                else hasFound = true;
            }
            var startIndex = ++left;
            return hasFound ? new Palindrome(input.Substring(startIndex, right - startIndex), startIndex)
            {
                IgnoreCase = option.IgnoreCase,
                LowestFirst = option.LowestFirst
            } : null;
        }
    }
}