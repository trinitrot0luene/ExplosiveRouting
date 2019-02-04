using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace ExplosiveRouting.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ParserBenchmark>();
        }
    }
}
