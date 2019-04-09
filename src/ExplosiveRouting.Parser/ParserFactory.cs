using System;
using ExplosiveRouting.Core;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// A default implementation of <see cref="IParserFactory"/> using ExplosiveRouting's <see cref="ITokenizer{TElement}"/> implementation.
    /// </summary>
    public sealed class ParserFactory : IParserFactory
    {
        public IParser Create()
        {
            var options = new ParserOptions();
            options.Validate();
            return new Parser(options, new Tokenizer(options));
        }

        public IParser Create(Action<IParserOptions> configureOptions)
        {
            var options = new ParserOptions();
            configureOptions(options);
            options.Validate();
            return new Parser(options, new Tokenizer(options));
        }
    }
}
