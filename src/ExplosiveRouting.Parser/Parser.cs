using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("ExplosiveRouting.Benchmarks")]
[assembly: InternalsVisibleTo("ExplosiveRouting.Tests")]

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Extracts tokens from an input string.
    /// </summary>
    public sealed class Parser : IParser
    {
        private IParserOptions Options { get; }

        private ITokenizer Tokenizer { get; }

        internal Parser(IParserOptions options, ITokenizer tokenizer)
        {
            Options = options;
            Tokenizer = tokenizer;
        }

        public IEnumerable<string> ExtractTokens(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                yield break;

            var source = input.AsMemory();
            var builder = new StringBuilder();
            foreach (var token in Tokenizer.YieldElements(source))
            {
                builder.Append(source.Slice(token.Start, token.Count));
                if (token.IsFin)
                {
                    yield return builder.ToString();
                    builder.Clear();
                }
            }
        }
    }
}
