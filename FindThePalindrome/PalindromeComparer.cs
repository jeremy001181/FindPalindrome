using System.Collections.Generic;

namespace FindThePalindrome
{
    public class PalindromeComparer : IComparer<Palindrome>
    {
        public int Compare(Palindrome x, Palindrome y)
        {
            return y.Text.Length.CompareTo(x.Text.Length);
        }

    }
}