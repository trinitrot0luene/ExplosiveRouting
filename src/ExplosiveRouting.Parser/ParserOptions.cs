using ExplosiveRouting.Core;
using System;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Configuration options for an <see cref="IParser"/>.
    /// </summary>
    public sealed class ParserOptions : IParserOptions
    {
        internal ParserOptions()
        {
            WhitespaceChars = new[] { ' ' };
            GroupingChars = new[] { '\"' };
            EscapeChars = new[] { '\\' };
        }

        /// <summary>
        /// Gets or sets which characters will be considered whitespace and delimit tokens.
        /// </summary>
        public char[] WhitespaceChars { get; set; }

        /// <summary>
        /// Gets or sets which characters will be considered grouping control characters.
        /// </summary>
        public char[] GroupingChars { get; set; }

        /// <summary>
        /// Gets or sets which characters will be considered escape control characters.
        /// </summary>
        public char[] EscapeChars { get; set; }

        /// <summary>
        /// Validates that the configuration is suitable for use in the instantiation of an <see cref="IParser"/>.
        /// </summary>
        public void Validate()
        {
            if (WhitespaceChars == null || WhitespaceChars.Length == 0)
                throw new ArgumentException("Whitespace characters must be set.");
            if (GroupingChars == null)
                throw new ArgumentException("Grouping characters must be set.");
            if (EscapeChars == null)
                throw new ArgumentException("Escape characters must be set.");
        }
    }
}
