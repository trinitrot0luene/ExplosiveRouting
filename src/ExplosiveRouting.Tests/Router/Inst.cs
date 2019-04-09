using ExplosiveRouting.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Tests.Router
{
    [TestFixture]
    public class Inst
    {
        [Test]
        public void DefaultCtor()
        {
            Assert.IsInstanceOf<ExplosiveRouting.Parser.Parser>(new ParserFactory().Create());
        }

        [Test]
        public void Configured()
        {
            Assert.IsInstanceOf<ExplosiveRouting.Parser.Parser>(new ParserFactory().Create(options =>
            {
                options.WhitespaceChars = new[] { ' ', ',' };
            }));
        }

        public void BadlyConfigured()
        {
            Assert.Throws<ArgumentException>(() => new ParserFactory().Create(options =>
            {
                options.WhitespaceChars = null;
            }));
        }
    }
}
