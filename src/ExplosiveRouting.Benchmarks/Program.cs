using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace ExplosiveRouting.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var parserSummary = BenchmarkRunner.Run<ParserBenchmark>();

            Console.ReadKey(true);

            var reflectionSummary = BenchmarkRunner.Run<ReflectionBenchmark>();
        }
    }
}
