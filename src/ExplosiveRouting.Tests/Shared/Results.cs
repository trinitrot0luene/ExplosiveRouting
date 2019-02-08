using ExplosiveRouting.Shared;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Tests.Shared
{
    [TestFixture]
    public class Results
    {
        [Test]
        public void OkResult()
        {
            Assert.NotNull(new OkResult());
            Assert.IsInstanceOf<ISuccessResult>(new OkResult());
        }
    }
}
