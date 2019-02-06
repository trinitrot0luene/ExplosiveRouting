using System;
using System.Collections.Generic;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Extracts token elements from a source string.
    /// </summary>
    public interface ITokenizer
    {
        IEnumerable<TokenElement> YieldElements(ReadOnlyMemory<char> source);
    }
}
