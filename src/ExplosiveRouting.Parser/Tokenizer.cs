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

        /// <summary>
        /// Lazily yields the elements of tokens found in the string.
        /// </summary>
        /// <param name="source">The source string to search for token elements.</param>
        /// <returns></returns>
        public IEnumerable<TokenElement> YieldElements(ReadOnlyMemory<char> source)
        {
            var flags = TokenFlags.None;
            var start = 0;
            for(int pos = 0; pos < source.Length; pos++)
            {
                switch (source.Span[pos])
                {
                    case char c when Array.BinarySearch(Options.EscapeChars, c) >= 0:
                        if (pos + 1 >= source.Length)
                            throw new ParsingException("Unexpected escape sequence at end of string.");
                        pos += 1;
                        yield return new TokenElement(pos, 1, false);
                        continue;
                    case char c when Array.BinarySearch(Options.WhitespaceChars, c) >= 0:
                        if (flags.HasFlag(TokenFlags.Grouped) || flags.HasFlag(TokenFlags.Yielded))
                            continue;
                        yield return new TokenElement(start, pos - start);
                        flags |= TokenFlags.Yielded;
                        continue;
                    case char c when Array.BinarySearch(Options.GroupingChars, c) >= 0:
                        if (flags.HasFlag(TokenFlags.Grouped))
                        {
                            yield return new TokenElement(start, (pos - start));
                            flags &= ~TokenFlags.Grouped;
                            flags |= TokenFlags.Yielded;
                        }
                        else
                        {
                            start = pos + 1;
                            flags |= (TokenFlags.Grouped);
                        }
                        continue;
                    default:
                        if (flags.HasFlag(TokenFlags.Grouped))
                            continue;
                        if (flags.HasFlag(TokenFlags.Yielded))
                        {
                            start = pos;
                            flags &= ~TokenFlags.Yielded;
                        }
                        if (source.Length - 1 == pos)
                        {
                            if (flags.HasFlag(TokenFlags.Grouped))
                                throw new ParsingException("Unterminated group at end of input.");

                            yield return new TokenElement(start, start == pos ? 1 : pos - start + 1);
                            yield break;
                        }
                        continue;
                }
            }
        }
    }
}
