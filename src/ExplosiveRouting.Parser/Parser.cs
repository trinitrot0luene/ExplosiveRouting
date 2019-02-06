using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExplosiveRouting.Benchmarks")]

namespace ExplosiveRouting.Parser
{
    public sealed class Parser : IParser
    {
        private IParserOptions Options { get; }

        private ITokenizer Tokenizer { get; }

        internal Parser(IParserOptions options, ITokenizer tokenizer)
        {
            Options = options;
            Tokenizer = tokenizer;
        }

        public string[] ExtractTokens(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new string[0];

            var source = input.AsMemory();

            return YieldTokens(source).ToArray();
        }

        private IEnumerable<string> YieldTokens(ReadOnlyMemory<char> source)
        {
            var map = Tokenizer.Map(source.Span);
            var flags = Token.None;
            var sPos = 0;
            for (int i = 0; i < source.Length; i++)
            {
                map[i] |= flags;
                
                switch (map[i])
                {
                    case Token t when t.HasFlag(Token.Text):
                        if (flags.HasFlag(Token.PrecededByWhitespace))
                        {
                            sPos = i;
                            ResetFlags(ref flags, Token.All);
                        }
                        if (i == source.Length - 1)
                            yield return source.Slice(sPos, ++i - sPos).ToString();
                        break;

                    #region Groupings

                    // Grouping token & already in a group.
                    case Token t when t.HasFlag(Token.Grouping) && t.HasFlag(Token.Grouped):
                        yield return source.Slice(sPos, i - sPos).ToString();

                        // This prevents whitespace from extracting a second token.
                        ResetFlags(ref flags, Token.Grouped);
                        flags |= Token.PrecededByWhitespace;
                        break;
                    // Begin grouping a token
                    case Token t when t.HasFlag(Token.Grouping):
                        sPos = i + 1;
                        ResetFlags(ref flags, Token.PrecededByWhitespace);
                        flags |= Token.Grouped;
                        break;
                    // In a group and not a grouped token.
                    case Token t when t.HasFlag(Token.Grouped):
                        break;
                    #endregion

                    #region Whitespaces

                    case Token t when t.HasFlag(Token.Whitespace):
                        if (!flags.HasFlag(Token.PrecededByWhitespace))
                        {
                            yield return source.Slice(sPos, i - sPos).ToString();
                            flags |= Token.PrecededByWhitespace;
                        }
                        break;

                    #endregion
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ResetFlags(ref Token source, Token flags)
            => source &= ~(flags);
    }
}
