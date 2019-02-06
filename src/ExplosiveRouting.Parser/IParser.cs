using System;
using System.Collections.Generic;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Extracts tokens from a string.
    /// </summary>
    public interface IParser
    {
        IEnumerable<string> ExtractTokens(string input);
    }
}
