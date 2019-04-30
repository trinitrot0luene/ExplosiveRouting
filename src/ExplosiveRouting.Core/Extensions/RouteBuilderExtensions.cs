using ExplosiveRouting.Discovery;
using ExplosiveRouting.Parsing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace ExplosiveRouting.Extensions
{
    public static class RouteBuilderExtensions
    {
        public static RouterBuilder<T> UseDefaultTypeMapping<T>(this RouterBuilder<T> builder)
        {
            var mapper = new TypeMapper();
            var assembly = Assembly.GetCallingAssembly();

            mapper.AddMapping(assembly, builder.Services);

            builder.Services.AddSingleton<ITypeMapper>(mapper);

            return builder;
        }

        public static RouterBuilder<T> UseDefaultTypeMapping<T>(this RouterBuilder<T> builder, Action<ITypeMapper> configureMapper)
        {
            var mapper = new TypeMapper();
            configureMapper(mapper);

            builder.Services.AddSingleton<ITypeMapper>(mapper);

            return builder;
        }

        public static RouterBuilder<TContext> UseDefaultRouteMapping<TContext>(this RouterBuilder<TContext> builder)
        {
            var mapper = new RouteMapper<TContext>();
            var assembly = Assembly.GetCallingAssembly();

            mapper.AddRoute(assembly, builder.Services);

            builder.Services.AddSingleton<IRouteMapper<TContext>>(mapper);

            return builder;
        }

        public static RouterBuilder<TContext> UseDefaultRouteMapping<TContext>(this RouterBuilder<TContext> builder, Action<IRouteMapper<TContext>> configureMapper)
        {
            var mapper = new RouteMapper<TContext>();
            configureMapper(mapper);

            builder.Services.AddSingleton<IRouteMapper<TContext>, RouteMapper<TContext>>();

            return builder;
        }

        public static RouterBuilder<TContext> UseDefaultParser<TContext>(this RouterBuilder<TContext> builder, Action<IParserOptions> configureOptions = null)
        {
            if (configureOptions == null)
            {
                builder.Services.AddSingleton(ParserFactory.Create());
            }
            else
            {
                builder.Services.AddSingleton(ParserFactory.Create(configureOptions));
            }

            return builder;
        }

        public static RouterBuilder<TContext> UseDefault<TContext>(this RouterBuilder<TContext> builder)
        {
            return builder
                .UseDefaultParser()
                .UseDefaultRouteMapping(mapper => mapper.AddRoute(Assembly.GetCallingAssembly(), builder.Services))
                .UseDefaultTypeMapping(mapper => mapper.AddMapping(Assembly.GetCallingAssembly(), builder.Services));
        }
    }
}
