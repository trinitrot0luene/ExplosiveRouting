using ExplosiveRouting.Core.Extensions;
using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading.Tasks;

namespace ExplosiveRouting.Core
{
    public sealed class Router<TContext>
    {
        public IParserOptions ParserOptions => Parser.Options;

        public IParser Parser { get; }

        private readonly RouterConfiguration _config;

        private readonly ConcurrentDictionary<Type, (ITypeConverter<TContext>, Func<ITypeConverter<TContext>, object, object>)> _converters;

        public Router(RouterConfiguration config)
        {
            this._config = config;
            this.Parser = this._config.ParserFactory.Create();
        }

        public Router(RouterConfiguration config, Action<IParserOptions> configureParser)
        {
            this._config = config;
            this.Parser = this._config.ParserFactory.Create(configureParser);
        }

        public Router<TContext> ImportConverters(Assembly assembly)
        {
            var types = assembly.GetTypes();
            var converterType = typeof(ITypeConverter<TContext>);
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsAssignableFrom(converterType))
                {
                    RegisterConverter(types[i]);
                }
            }

            return this;
        }

        public Router<TContext> ImportConverter(Type converterType)
        {
            if (!converterType.IsAssignableFrom(typeof(ITypeConverter<TContext>)))
                throw new ArgumentException("Converters must inherit from a suitable ITypeConverter<TContext>");

            RegisterConverter(converterType);
            
            return this;
        }

        private void RegisterConverter(Type converterType)
        {
            var typeConverter = converterType.CreateInstanceOf<ITypeConverter<TContext>>(_config.Services);
            var converterMethod = converterType
                .GetType()
                .GetMethod("Convert");

            var invokerMethod = converterMethod.CreateGenericInvoker<ITypeConverter<TContext>, object, object>();

            _converters[typeConverter.TargetType] = (typeConverter, invokerMethod);
        }

        private void RegisterType(Type targetType, Type parentType = null)
        {

        }
    }
}
