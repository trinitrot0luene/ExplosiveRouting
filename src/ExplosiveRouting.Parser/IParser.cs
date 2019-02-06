using System;
using System.Collections.Generic;

namespace ExplosiveRouting.Parser
{
    public interface IParser
    {
        string[] ExtractTokens(string input);
    }
}
