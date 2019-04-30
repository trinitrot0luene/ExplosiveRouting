using ExplosiveRouting;
using ExplosiveRouting.Parsing;
using NUnit.Framework;
using System;
using System.Linq;

namespace ExplosiveRouting.Tests.Parser
{
    [TestFixture]
    public class ParserTests
    {
        private IParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = ParserFactory.Create(options =>
            {
                options.GroupingChars = new[] { '\"' };
                options.WhitespaceChars = new[] { ' ' };
                options.EscapeChars = new[] { '\\' };
            });
        }

        private string[] Parse(string input) => _parser.YieldTokens(input).ToArray();

        [Test]
        public void Create()
        {
            Assert.IsInstanceOf(typeof(IParser), ParserFactory.Create());
            Assert.IsInstanceOf(typeof(IParser), ParserFactory.Create(options =>
            {
                options.GroupingChars = new[] { '\"' };
                options.WhitespaceChars = new[] { ' ' };
                options.EscapeChars = new[] { '\\' };
            }));
        }

        [Test]
        public void ValidateOptions()
        {
            Assert.Throws<ArgumentException>(() => ParserFactory.Create(options => options.WhitespaceChars = null));
            Assert.Throws<ArgumentException>(() => ParserFactory.Create(options => options.GroupingChars = null));
            Assert.Throws<ArgumentException>(() => ParserFactory.Create(options => options.EscapeChars = null));
        }

        [TestCase("")]
        public void EmptyString(string input)
        {
            var parsedValues = Parse(input);

            Assert.AreEqual(0, parsedValues.Length);
        }

        [TestCase("a")]
        public void SingleCharacter(string input)
        {
            var parsedValues = Parse(input);

            Assert.AreEqual(1, parsedValues.Length);
            Assert.AreEqual("a", parsedValues[0]);
        }

        [TestCase("a b c")]
        public void MultiCharacter(string input)
        {
            var parsedValues = Parse(input);

            Assert.AreEqual(3, parsedValues.Length);
            Assert.AreEqual("a", parsedValues[0]);
            Assert.AreEqual("b", parsedValues[1]);
            Assert.AreEqual("c", parsedValues[2]);
        }

        [TestCase("lorem")]
        public void SingleWord(string input)
        {
            var parsedValues = Parse(input);

            Assert.AreEqual(1, parsedValues.Length);
            Assert.AreEqual("lorem", parsedValues[0]);
        }

        [TestCase("lorem ipsum dolor")]
        public void MultiWord(string input)
        {
            var parsedValues = Parse(input);

            Assert.AreEqual(3, parsedValues.Length);
            Assert.AreEqual("lorem", parsedValues[0]);
            Assert.AreEqual("ipsum", parsedValues[1]);
            Assert.AreEqual("dolor", parsedValues[2]);
        }

        [TestCase("lorem     ipsum   dolor  ")]
        public void MultiWordSpaced(string input)
        {
            var parsedValues = Parse(input);

            Assert.AreEqual(3, parsedValues.Length);
            Assert.AreEqual("lorem", parsedValues[0]);
            Assert.AreEqual("ipsum", parsedValues[1]);
            Assert.AreEqual("dolor", parsedValues[2]);
        }

        [TestCase(@"""lorem ipsum"" dolor sit")]
        public void MultiWordGrouped(string input)
        {
            var parsedValues = Parse(input);

            Assert.AreEqual(3, parsedValues.Length);
            Assert.AreEqual("lorem ipsum", parsedValues[0]);
            Assert.AreEqual("dolor", parsedValues[1]);
            Assert.AreEqual("sit", parsedValues[2]);
        }

        [TestCase("lorem \"ipsum dolor\" \"sit\" amet")]
        public void MultiWordTwoGroupSingleWordInGroup(string input)
        {
            var parsedValues = Parse(input);

            Assert.AreEqual(4, parsedValues.Length);
            Assert.AreEqual("lorem", parsedValues[0]);
            Assert.AreEqual("ipsum dolor", parsedValues[1]);
            Assert.AreEqual("sit", parsedValues[2]);
            Assert.AreEqual("amet", parsedValues[3]);
        }

        [TestCase("lorem \\\"ipsum \\\"dolor sit")]
        public void EscapedCharacters(string input)
        {
            var parsedValues = Parse(input);
         
            Assert.AreEqual(4, parsedValues.Length);
            Assert.AreEqual("lorem", parsedValues[0]);
            Assert.AreEqual("\"ipsum", parsedValues[1]);
            Assert.AreEqual("\"dolor", parsedValues[2]);
            Assert.AreEqual("sit", parsedValues[3]);
        }

        [TestCase("lorem ipsum\\")]
        public void ExceptionThrownForBadEscapes(string input)
        {
            Assert.Throws<ParsingException>(() => Parse(input));
        }

        [TestCase("lorem \"ipsum dolor")]
        public void ExceptionThrownForUnterminatedGroup(string input)
        {
            Assert.Throws<ParsingException>(() => Parse(input));
        }
    }
}
