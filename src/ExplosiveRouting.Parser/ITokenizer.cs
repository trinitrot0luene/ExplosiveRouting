using System;
using System.Collections.Generic;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Extracts token elements from a source string.
    /// </summary>
    internal interface ITokenizer
    {
        IEnumerable<TokenElement> YieldElements(ReadOnlyMemory<char> source);
    }
}
