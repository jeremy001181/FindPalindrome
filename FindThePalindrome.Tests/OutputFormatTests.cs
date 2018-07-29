using NUnit.Framework;
using System.Linq;

namespace FindThePalindrome.Tests
{
    [TestFixture]
    class OutputFormatTests
    {
        private PalindromeFinder palindromeFinder = new PalindromeFinder(new Option());

        [Test]
        public void Should_output_correct_format() {
            var result = palindromeFinder.FindLongestPalindrome("a")
                                         .Single();
            Assert.AreEqual("Text: a, Index: 0, Length: 1", result.ToString());
        }
    }
}
