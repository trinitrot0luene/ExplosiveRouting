using System;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Factory for <see cref="IParser"/>.
    /// </summary>
    public static class ParserFactory
    {
        /// <summary>
        /// Creates a new instance of <see cref="IParser"/>.
        /// </summary>
        /// <param name="configureOptions">Method to configure the parsing options.</param>
        /// <param name="tokenizer">A tokenizer, used to generate a map of all supplied characters.</param>
        /// <returns></returns>
        public static IParser CreateParser(Action<IParserOptions> configureOptions, ITokenizer tokenizer = null)
        {
            var options = new ParserOptions();
            configureOptions(options);
            options.Validate();

            if (tokenizer == null)
                tokenizer = new Tokenizer(options);

            return new Parser(options, tokenizer);
        }
    }
}
