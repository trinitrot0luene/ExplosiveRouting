using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Parser
{
    internal sealed class Tokenizer : ITokenizer
    {
        private IParserOptions Options { get; set; }

        internal Tokenizer(IParserOptions options)
        {
            Options = options;
        }

        public Token[] Map(ReadOnlySpan<char> source)
        {
            var map = (Token[])Array.CreateInstance(typeof(Token), source.Length);
            for (int i = 0; i < source.Length; i++)
                map[i] = GetToken(source[i]);

            return map;
        }

        private Token GetToken(char sourceChar)
        {
            switch (sourceChar)
            {
                case char c when Array.BinarySearch<char>(Options.WhitespaceChars, c) >= 0:
                    return Token.Whitespace;
                case char c when Array.BinarySearch<char>(Options.GroupingChars, c) >= 0:
                    return Token.Grouping;
                case char c when Array.BinarySearch<char>(Options.EscapeChars, c) >= 0:
                    return Token.Escape;
                default:
                    return Token.Text;
            }
        }
    }
}
