using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ExplosiveRouting.Extensions;

namespace ExplosiveRouting.Benchmarks
{
    [CoreJob, MemoryDiagnoser]
    public class ReflectionBenchmark
    {
        private A _a;

        private MethodInfo _demoMethod14;

        private Func<object, object[], object> _invoker;

        [GlobalSetup]
        public void Setup()
        {
            _a = new A();
            _demoMethod14 = typeof(A).GetMethod("Demo14");
            _invoker = _demoMethod14.CreateCompiledInvocationDelegate();
        }

        private class A
        {
            public int Demo14(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n) { return 0; }
        }

        [Benchmark]
        public void FastGenerics()
        {
            int ret = (int)_invoker(_a, new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
        }

        [Benchmark]
        public void MethodInfoInvoke()
        {
            int ret = (int)_demoMethod14.Invoke(_a, new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
        }
    }
}
