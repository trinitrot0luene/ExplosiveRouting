using System;
using System.Collections.Generic;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Extracts tokens from an input string.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Lazily yields tokens from the input string.
        /// </summary>
        /// <param name="input">The string to search for tokens.</param>
        /// <returns></returns>
        IEnumerable<string> ExtractTokens(string input);
    }
}
