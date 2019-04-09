using ExplosiveRouting.Core;
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

        [Test]
        public void ErrorResult()
        {
            Assert.NotNull(new ErrorResult());
            Assert.IsInstanceOf<IFailureResult>(new ErrorResult());
        }

        [Test]
        public void AggregateResult()
        {
            var ok = new OkResult();
            var error = new ErrorResult();
            var aggregate = new AggregateResult(new List<IResult> { ok, error }.AsReadOnly());
            Assert.NotNull(aggregate);
            Assert.AreEqual(false, aggregate.IsSuccess);
        }
    }
}
