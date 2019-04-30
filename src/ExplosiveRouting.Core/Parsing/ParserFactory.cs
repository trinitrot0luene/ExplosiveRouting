using System;
using ExplosiveRouting;

namespace ExplosiveRouting.Parsing
{
    /// <summary>
    /// A default implementation of <see cref="IParserFactory"/> using ExplosiveRouting's <see cref="ITokenizer{TElement}"/> implementation.
    /// </summary>
    public static class ParserFactory
    {
        private static ParserOptions _defaultOptions = new ParserOptions();

        public static IParser Create()
        {
            return new Parser(new Tokenizer(_defaultOptions));
        }

        public static IParser Create(Action<IParserOptions> configureOptions)
        {
            var options = new ParserOptions();
            configureOptions(options);
            options.Validate();
            return new Parser(new Tokenizer(options));
        }
    }
}
