using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Represents a slice of a token to be extracted from the source string.
    /// </summary>
    internal readonly struct TokenElement
    {
        /// <summary>
        /// Gets the index from where to start extracting the token.
        /// </summary>
        public int Start { get; }

        /// <summary>
        /// Gets the number of elements confirmed to be in this token.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Gets whether this is the last section of this token.
        /// </summary>
        public bool IsFin { get; }

        internal TokenElement(int start, int count, bool isFin = true)
        {
            Start = start;
            Count = count;
            IsFin = isFin;
        }
    }
}
