namespace FindThePalindrome
{
    public class Option
    {
        public bool IgnoreCase { get; set; } = true;
        /// <summary>
        /// Instruct how many palindromes to find
        /// </summary>
        public int Count { get; set; } = 3;
        /// <summary>
        /// True, return palindrome that has lower index if any duplicate; otherwise return the one has higher index
        /// </summary>
        public bool LowestFirst { get; set; } = true;
    }
}