using BenchmarkDotNet.Attributes;
using ExplosiveRouting.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Benchmarks
{
    [ClrJob(baseline: true), CoreJob]
    public class ParserBenchmark
    {
        private IParser Parser { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            Parser = ParserFactory.CreateParser(options => { });
        }

        [Params("", "a", "a b c", "lorem", "lorem ipsum dolor", "\"lorem ipsum\" dolor sit", 
            "lorem     ipsum    dolor", "lorem \"ipsum dolor\" \"sit\" amet")]
        public string Input;

        [Benchmark]
        public void Tokenize() => Parser.Tokenize(Input);
    }
}
