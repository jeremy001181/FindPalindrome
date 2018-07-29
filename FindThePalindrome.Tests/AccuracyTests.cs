using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindThePalindrome.Tests
{
    [TestFixture]
    public class AccuracyTests
    {
        private PalindromeFinder palindromeFinder = new PalindromeFinder(new Option());

        private void AssertPalindromeFinding(IEnumerable<Palindrome> result, string expectedText, int expectedIndex)
        {
            Assert.DoesNotThrow(() => result.Single(p => p.Text.Equals(expectedText) && p.Start == expectedIndex),
                $"Cannot find {expectedText} at {expectedIndex}");
        }

        [TestCase("assa")]
        [TestCase("asdsa")]
        [TestCase("qqqqTqqqq")]
        [TestCase("qqqq")]
        [TestCase("")]
        [TestCase("a")]
        public void Should_find_itself_as_one_single_palindrome(string expected)
        {
            var result = palindromeFinder.FindLongestPalindrome(expected);

            Assert.AreEqual(1, result.Count());

            AssertPalindromeFinding(result, expected, 0);
        }

        [TestCase("sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop")]
        public void Should_find_palindrome_correctly(string input)
        {
            var result = palindromeFinder.FindLongestPalindrome(input);

            Assert.AreEqual(3, result.Count());

            AssertPalindromeFinding(result, "hijkllkjih", 23);
            AssertPalindromeFinding(result, "abccba", 5);
            AssertPalindromeFinding(result, "defggfed", 13);
        }

        [Test]
        public void Should_return_individual_characters_as_palindromes()
        {
            var result = palindromeFinder.FindLongestPalindrome("abc");

            Assert.AreEqual(3, result.Count());
            
            AssertPalindromeFinding(result, "a", 0);
            AssertPalindromeFinding(result, "b", 1);
            AssertPalindromeFinding(result, "c", 2);
        }

        [Test]
        public void Should_remove_duplicates()
        {
            var result = palindromeFinder.FindLongestPalindrome("dsd3TT56TT4dsd");

            AssertPalindromeFinding(result, "dsd", 0);
            AssertPalindromeFinding(result, "TT", 4);
        }
    }
}
