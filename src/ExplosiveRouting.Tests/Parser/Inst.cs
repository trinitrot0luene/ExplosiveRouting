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
            var router = new Core.Router<object>(new RouterConfiguration()
            {
                ParserFactory = new ParserFactory()
            });
            Assert.IsInstanceOf<Core.Router<object>>(router);

            Assert.NotNull(router.Parser);
            Assert.NotNull(router.ParserOptions);
        }

        [Test]
        public void CreateBadly()
        {
            Assert.Throws<NullReferenceException>(() => new Core.Router<object>(new RouterConfiguration()
            {
                ParserFactory = null
            }));

            Assert.Throws<ArgumentException>(() => new Core.Router<object>(new RouterConfiguration()
            {
                ParserFactory = new ParserFactory()
            }, options => options.EscapeChars = null));
        }
    }
}
