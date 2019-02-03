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
        /// <returns></returns>
        public static IParser CreateParser(Action<IParserOptions> configureOptions)
        {
            var options = new ParserOptions();
            configureOptions(options);
            options.Validate();

            return new Parser(options);
        }
    }
}
