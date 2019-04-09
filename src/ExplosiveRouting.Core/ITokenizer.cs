using System;
using System.Collections.Generic;

namespace ExplosiveRouting.Core
{
    /// <summary>
    /// Extracts token elements from a source string.
    /// </summary>
    /// <typeparam name="TElement">The elements returned by the <see cref="ITokenizer{TElement}"/></typeparam>
    public interface ITokenizer<TElement>
    {
        /// <summary>
        /// Lazily yields token elements from a source string.
        /// </summary>
        /// <param name="source">A wrapper over the memory where the source string resides.</param>
        /// <returns></returns>
        IEnumerable<TElement> YieldElements(ReadOnlyMemory<char> source);
    }
}
