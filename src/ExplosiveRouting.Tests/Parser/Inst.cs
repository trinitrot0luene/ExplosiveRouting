using ExplosiveRouting.Core;
using ExplosiveRouting.Parser;
using NUnit.Framework;
using System;

namespace ExplosiveRouting.Tests.Parser
{
    [TestFixture]
    public class Inst
    {
        [Test]
        public void CreateWithDefaultConfig()
        {
            Assert.IsInstanceOf<Core.Router>(new Core.Router(new ParserFactory().Create));
        }

        [Test]
        public void CreateBadly()
        {
            Assert.Throws<ArgumentException>(() => new Core.Router(() => default(IParser)));
        }
    }
}
