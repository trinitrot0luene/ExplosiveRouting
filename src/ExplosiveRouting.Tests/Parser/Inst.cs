using ExplosiveRouting.Parser;
using NUnit.Framework;
using System;

namespace ExplosiveRouting.Tests.Parser
{
    [TestFixture]
    public class Inst
    {
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
    }
}
