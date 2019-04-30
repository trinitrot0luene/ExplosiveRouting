using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting
{
    public interface IParser
    {
        IEnumerable<string> YieldTokens(string input);
    }
}
