using BenchmarkDotNet.Attributes;
using ExplosiveRouting.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosiveRouting.Benchmarks
{
    [CoreJob, MemoryDiagnoser]
    public class ParserBenchmark
    {
        private IParser Parser { get; set; }

        private ITokenizer Tokenizer { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            Parser = ParserFactory.Create(options => { });
            Tokenizer = new Tokenizer(new ParserOptions());
        }

        [Params("", "a", "a b c", "lorem", "lorem ipsum dolor", "\"lorem ipsum\" dolor sit", 
            "lorem     ipsum    dolor", "lorem \"ipsum dolor\" \"sit\" amet")]
        public string Input;

        [Benchmark]
        public void ExtractTokens() => Parser.ExtractTokens(Input).ToList();
    }
}
