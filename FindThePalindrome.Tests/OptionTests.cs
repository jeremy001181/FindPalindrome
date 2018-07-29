using NUnit.Framework;
using System.Linq;

namespace FindThePalindrome.Tests
{
    [TestFixture]
    class OptionTests
    {
        [TestCase(true,  0)]
        [TestCase(false, 5)]
        public void Should_honour_LowestFirst_option(bool lowestFirst, int expectedIndex)
        {
            var palindromeFinder = new PalindromeFinder(new Option
            {
                LowestFirst = lowestFirst
            });
            var result = palindromeFinder.FindLongestPalindrome("dsd78dsd")
                                         .Single(p => p.Text == "dsd");

            Assert.AreEqual(expectedIndex, result.Start);
        }

        [TestCase(true, "dsd", "u", "0")]
        [TestCase(false, "dsd", "DSD", "dSd")]
        public void Should_honour_case_sensitive_option(bool ignoreCase, params string[] expecteds)
        {
            var palindromeFinder = new PalindromeFinder(new Option
            {
                IgnoreCase = ignoreCase
            });
            var result = palindromeFinder.FindLongestPalindrome("dsdu0DSD9dSd").ToList();

            Assert.AreEqual(expecteds.Count(), result.Count());
            foreach (var expected in expecteds)
            {
                result.Any(p => p.Text.Equals(expected));
            }
        }

        [Test]
        public void Should_honour_count_option()
        {
            var palindromeFinder = new PalindromeFinder(new Option
            {
                Count = 2
            });
            var result = palindromeFinder.FindLongestPalindrome("abc").ToList();

            Assert.AreEqual(2, result.Count());
        }
    }
}
