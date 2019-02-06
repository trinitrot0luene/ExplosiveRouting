using ExplosiveRouting.Parser;
using NUnit.Framework;
using System;

namespace ExplosiveRouting.Tests.Parser
{
    [TestFixture]
    public class ExtractTokensrTests
    {
        private IParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = ParserFactory.CreateParser(options =>
            {
                options.GroupingChars = new[] { '\"' };
                options.WhitespaceChars = new[] { ' ' };
                options.EscapeChars = new[] { '\\' };
            });
        }

        [Test]
        public void FactoryMethod()
        {
            Assert.Throws<ArgumentException>(() => ParserFactory.CreateParser(options =>
            {
                options.GroupingChars = null;
                options.WhitespaceChars = null;
                options.EscapeChars = null;
            }));

            Assert.NotNull(ParserFactory.CreateParser(options =>
            {
                options.GroupingChars = new[] { '\"', '\'' };
                options.WhitespaceChars = new[] { ' ' };
                options.EscapeChars = new[] { '\\' };
            }));
        }

        [TestCase("")]
        public void EmptyString(string input)
        {
            var parsedValues = _parser.ExtractTokens(input);

            Assert.AreEqual(parsedValues.Length, 0);
        }

        [TestCase("a")]
        public void SingleCharacter(string input)
        {
            var parsedValues = _parser.ExtractTokens(input);

            Assert.AreEqual(parsedValues.Length, 1);
            Assert.AreEqual(parsedValues[0], "a");
        }

        [TestCase("a b c")]
        public void MultiCharacter(string input)
        {
            var parsedValues = _parser.ExtractTokens(input);

            Assert.AreEqual(parsedValues.Length, 3);
            Assert.AreEqual(parsedValues[0], "a");
            Assert.AreEqual(parsedValues[1], "b");
            Assert.AreEqual(parsedValues[2], "c");
        }

        [TestCase("lorem")]
        public void SingleWord(string input)
        {
            var parsedValues = _parser.ExtractTokens(input);

            Assert.AreEqual(parsedValues.Length, 1);
            Assert.AreEqual(parsedValues[0], "lorem");
        }

        [TestCase("lorem ipsum dolor")]
        public void MultiWord(string input)
        {
            var parsedValues = _parser.ExtractTokens(input);

            Assert.AreEqual(parsedValues.Length, 3);
            Assert.AreEqual(parsedValues[0], "lorem");
            Assert.AreEqual(parsedValues[1], "ipsum");
            Assert.AreEqual(parsedValues[2], "dolor");
        }

        [TestCase("lorem     ipsum   dolor  ")]
        public void MultiWordSpaced(string input)
        {
            var parsedValues = _parser.ExtractTokens(input);

            Assert.AreEqual(parsedValues.Length, 3);
            Assert.AreEqual(parsedValues[0], "lorem");
            Assert.AreEqual(parsedValues[1], "ipsum");
            Assert.AreEqual(parsedValues[2], "dolor");
        }

        [TestCase(@"""lorem ipsum"" dolor sit")]
        public void MultiWordGrouped(string input)
        {
            var parsedValues = _parser.ExtractTokens(input);

            Assert.AreEqual(parsedValues.Length, 3);
            Assert.AreEqual(parsedValues[0], "lorem ipsum");
            Assert.AreEqual(parsedValues[1], "dolor");
            Assert.AreEqual(parsedValues[2], "sit");
        }

        [TestCase("lorem \"ipsum dolor\" \"sit\" amet")]
        public void MultiWordTwoGroupSingleWordInGroup(string input)
        {
            var parsedValues = _parser.ExtractTokens(input);

            Assert.AreEqual(parsedValues.Length, 4);
            Assert.AreEqual(parsedValues[0], "lorem");
            Assert.AreEqual(parsedValues[1], "ipsum dolor");
            Assert.AreEqual(parsedValues[2], "sit");
            Assert.AreEqual(parsedValues[3], "amet");
        }

        /* Character escapes are currently unsupported.
        * [TestCase("lorem \\\"ipsum \\\"dolor sit")]
        * public void EscapedCharacters(string input)
        * {
        *     var parsedValues = _parser.ExtractTokens(input);
        * 
        *     Assert.AreEqual(parsedValues.Length, 4);
        *     Assert.AreEqual(parsedValues[0], "lorem");
        *     Assert.AreEqual(parsedValues[1], "\"ipsum");
        *     Assert.AreEqual(parsedValues[2], "\"dolor");
        *     Assert.AreEqual(parsedValues[3], "sit");
        * }
        */
    }
}
