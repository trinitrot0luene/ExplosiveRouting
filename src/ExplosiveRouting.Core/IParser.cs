using System;
using System.Collections.Generic;

namespace ExplosiveRouting.Core
{
    /// <summary>
    /// Extracts tokens from an input string.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Gets the options the <see cref="IParser"/> was configured with.
        /// </summary>
        IParserOptions Options { get; }

        /// <summary>
        /// Lazily yields tokens from the input string.
        /// </summary>
        /// <param name="input">The string to search for tokens.</param>
        /// <returns></returns>
        IEnumerable<string> ExtractTokens(string input);
    }
}
