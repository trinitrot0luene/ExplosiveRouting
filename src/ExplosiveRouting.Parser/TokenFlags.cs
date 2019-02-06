using System;

namespace ExplosiveRouting.Parser
{
    [Flags]
    internal enum TokenFlags
    {
        None = 0,
        Yielded = 1,
        Grouped = 2
    }
}
