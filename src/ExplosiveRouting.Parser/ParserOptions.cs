using System;

namespace ExplosiveRouting.Parser
{
    public sealed class ParserOptions : IParserOptions
    {
        internal ParserOptions()
        {
            WhitespaceChars = new[] { ' ' };
            GroupingChars = new[] { '\"' };
            EscapeChars = new[] { '\\' };
        }

        public char[] WhitespaceChars { get; set; }

        public char[] GroupingChars { get; set; }

        public char[] EscapeChars { get; set; }

        public void Validate()
        {
            if (WhitespaceChars == null)
                throw new ArgumentException("Whitespace characters must be set.");
            if (GroupingChars == null)
                throw new ArgumentException("Grouping characters must be set.");
            if (EscapeChars == null)
                throw new ArgumentException("Escape characters must be set.");
        }
    }
}
