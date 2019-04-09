using NUnit.Framework;
using ExplosiveRouting.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Tests.Reflection
{
    [TestFixture]
    public class CreateGenericInvoker
    {
        private static readonly A a = new A();

        [Test]
        public void Test1()
        {
            var invoker = typeof(A).GetMethod("Demo1").CreateGenericInvoker<A, int, int>();
            Assert.AreEqual(0, invoker(a, 1));
        }

        [Test]
        public void Test2()
        {
            var invoker = typeof(A).GetMethod("Demo2").CreateGenericInvoker<A, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2));
        }

        [Test]
        public void Test3()
        {
            var invoker = typeof(A).GetMethod("Demo3").CreateGenericInvoker<A, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3));
        }

        [Test]
        public void Test4()
        {
            var invoker = typeof(A).GetMethod("Demo4").CreateGenericInvoker<A, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4));
        }

        [Test]
        public void Test5()
        {
            var invoker = typeof(A).GetMethod("Demo5").CreateGenericInvoker<A, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5));
        }

        [Test]
        public void Test6()
        {
            var invoker = typeof(A).GetMethod("Demo6").CreateGenericInvoker<A, int, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5, 6));
        }

        [Test]
        public void Test7()
        {
            var invoker = typeof(A).GetMethod("Demo7").CreateGenericInvoker<A, int, int, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5, 6, 7));
        }

        [Test]
        public void Test8()
        {
            var invoker = typeof(A).GetMethod("Demo8").CreateGenericInvoker<A, int, int, int, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5, 6, 7, 8));
        }

        [Test]
        public void Test9()
        {
            var invoker = typeof(A).GetMethod("Demo9").CreateGenericInvoker<A, int, int, int, int, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5, 6, 7, 8, 9));
        }

        [Test]
        public void Test10()
        {
            var invoker = typeof(A).GetMethod("Demo10").CreateGenericInvoker<A, int, int, int, int, int, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
        }

        [Test]
        public void Test11()
        {
            var invoker = typeof(A).GetMethod("Demo11").CreateGenericInvoker<A, int, int, int, int, int, int, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11));
        }

        [Test]
        public void Test12()
        {
            var invoker = typeof(A).GetMethod("Demo12").CreateGenericInvoker<A, int, int, int, int, int, int, int, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12));
        }

        [Test]
        public void Test13()
        {
            var invoker = typeof(A).GetMethod("Demo13").CreateGenericInvoker<A, int, int, int, int, int, int, int, int, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
        }

        [Test]
        public void Test14()
        {
            var invoker = typeof(A).GetMethod("Demo14").CreateGenericInvoker<A, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>();
            Assert.AreEqual(0, invoker(a, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
        }

        private class A
        {

            public int Demo1(int a) { return 0; }

            public int Demo2(int a, int b) { return 0; }

            public int Demo3(int a, int b, int c) { return 0; }

            public int Demo4(int a, int b, int c, int d) { return 0; }

            public int Demo5(int a, int b, int c, int d, int e) { return 0; }

            public int Demo6(int a, int b, int c, int d, int e, int f) { return 0; }

            public int Demo7(int a, int b, int c, int d, int e, int f, int g) { return 0; }

            public int Demo8(int a, int b, int c, int d, int e, int f, int g, int h) { return 0; }

            public int Demo9(int a, int b, int c, int d, int e, int f, int g, int h, int i) { return 0; }

            public int Demo10(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j) { return 0; }

            public int Demo11(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k) { return 0; }

            public int Demo12(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l) { return 0; }

            public int Demo13(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m) { return 0; }

            public int Demo14(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n) { return 0; }
        }
    }
}
