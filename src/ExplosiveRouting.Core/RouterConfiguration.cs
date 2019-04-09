using System;

namespace ExplosiveRouting.Core
{
    public class RouterConfiguration
    {
        public IServiceProvider Services { get; set; }

        public IParserFactory ParserFactory { get; set; }
    }
}