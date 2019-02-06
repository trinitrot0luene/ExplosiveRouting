using System;

namespace ExplosiveRouting.Parser
{
    public interface ITokenizer
    {
        Token[] Map(ReadOnlySpan<char> source);
    }
}
