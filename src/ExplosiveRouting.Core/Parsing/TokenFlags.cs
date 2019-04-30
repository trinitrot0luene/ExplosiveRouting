using System;

namespace ExplosiveRouting.Parsing
{
    [Flags]
    internal enum TokenFlags
    {
        None = 0,
        Yielded = 1,
        Grouped = 2
    }
}
