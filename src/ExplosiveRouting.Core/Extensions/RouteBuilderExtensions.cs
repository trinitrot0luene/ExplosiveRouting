using ExplosiveRouting.Discovery;
using ExplosiveRouting.Parsing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Extensions
{
    public static class RouteBuilderExtensions
    {
        public static RouterBuilder<T> UseDefaultTypeMapping<T>(this RouterBuilder<T> builder)
        {
            builder.Services.AddSingleton<ITypeMapper, TypeMapper>();

            return builder;
        }

        public static RouterBuilder<TContext> UseDefaultRouteMapping<TContext>(this RouterBuilder<TContext> builder)
        {
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
                .UseDefaultRouteMapping()
                .UseDefaultTypeMapping();
        }
    }
}
