using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Tests.Middleware
{
    [TestFixture]
    public class Inst
    {
        [Test]
        public void Factory()
        {
            Assert.IsInstanceOf<IMiddleware>(MiddlewareFactory.Create(options =>
            {

            }));
        }
    }
}
