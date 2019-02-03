using System;

namespace ExplosiveRouting.Parser
{
    [Flags]
    internal enum Token
    {
        None = 0,

        Text = 1,

        Grouping = 2,

        Grouped = 4,

        Whitespace = 8,

        PrecededByWhitespace = 16,

        Escape = 32,

        Escaped = 64,

        All = None | Text | Grouping | Grouped | Whitespace | PrecededByWhitespace | Escape | Escaped
    }
}
