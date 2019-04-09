using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveRouting.Core
{
    public sealed class Router
    {
        public IParserOptions ParserOptions => Parser.Options;

        public IParser Parser { get; }

        private readonly RouterConfiguration _config;

        public Router(RouterConfiguration config)
        {
            this.Parser = config.ParserFactory.Create();
            if (this.Parser == null)
                throw new ArgumentException("The provided Func<IParser> returned null.");
        }

        public Router(RouterConfiguration config, Action<IParserOptions> configureParser)
        {
            this.Parser = config.ParserFactory.Create(configureParser);
            if (this.Parser == null)
                throw new ArgumentException("The provided factory method for creating a parser returned null.");
        }

        public async Task RouteAsync(string input)
        {
            var tokens = Parser.ExtractTokens(input);
        }
    }
}
