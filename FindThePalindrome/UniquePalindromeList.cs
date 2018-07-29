using System.Collections.Generic;

namespace FindThePalindrome
{
    public class UniquePalindromeList : List<Palindrome>
    {
        public UniquePalindromeList TryAdd(Palindrome palindrome)
        {
            if (palindrome != null && !this.Contains(palindrome))
            {
                this.Add(palindrome);
            }
            return this;
        }
    }
}