using System;
using System.Threading;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Factory for <see cref="IParser"/>.
    /// </summary>
    public static class ParserFactory
    {
        /// <summary>
        /// Default options to use when creating new parsers.
        /// </summary>
        private static IParserOptions Options { get; set; }

        /// <summary>
        /// Synchronises access to <see cref="Options"/>.
        /// </summary>
        private static SemaphoreSlim OptionsSynchronizer = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Creates a new instance of <see cref="IParser"/>.
        /// </summary>
        /// <param name="configureOptions">Method to configure the parsing options.</param>
        /// <returns></returns>
        public static IParser Create(Action<IParserOptions> configureOptions)
        {
            var options = new ParserOptions();
            configureOptions(options);
            options.Validate();

            var tokenizer = new Tokenizer(options);

            return new Parser(options, tokenizer);
        }

        public static IParserOptions Configure(Action<IParserOptions> configureOptions)
        {
            var options = new ParserOptions();
            configureOptions(options);
            options.Validate();

            OptionsSynchronizer.Wait();
            
            try
            {
                Options = options;
                return Options;
            }
            finally
            {
                OptionsSynchronizer.Release();
            }
        }
    }
}
