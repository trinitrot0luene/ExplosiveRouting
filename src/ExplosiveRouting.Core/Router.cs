using ExplosiveRouting.Discovery;
using ExplosiveRouting.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveRouting
{
    public sealed class Router<TContext>
    {
        private IServiceCollection _serviceSource;

        private IServiceProvider _services;

        public Router(IServiceCollection serviceSource, IServiceProvider services)
        {
            this._serviceSource = serviceSource;
            this._services = services;
        }

        public async Task RouteAsync(TContext context, string input)
        {
            var parser = _services.GetRequiredService<IParser>();

            var tokens = parser.YieldTokens(input).ToArray();

            var mapper = _services.GetRequiredService<IRouteMapper<TContext>>();
            
            if (!mapper.TryGetRoute(tokens, out (Route route, int pos) routeInfo))
            {
                return;
            }

            var typeMapper = _services.GetRequiredService<ITypeMapper>();

            var inputs = await BuildInputsAsync(
                context, 
                routeInfo.route.MethodInfo, 
                tokens.AsMemory().Slice(routeInfo.pos + 1), 
                typeMapper
                ); // TODO: Add ParamArrayAttribute

            var moduleInst = _services.GetRequiredService(routeInfo.route.MethodInfo.DeclaringType);

            var routeTask = (Task)routeInfo.route.Callback(moduleInst, inputs);

            await routeTask.ConfigureAwait(false);
        }

        private async Task<object[]> BuildInputsAsync(TContext context, MethodInfo info, ReadOnlyMemory<string> inputs, ITypeMapper mapper)
        {
            var parameters = info.GetParameters();
            var inputBuffer = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                if (i >= inputs.Length && !parameters[i].IsOptional)
                    throw new ArgumentException("There were not enough tokens in the input string to parse required arguments from.");

                if (mapper.TryGetMapping(parameters[i].ParameterType, out var map) 
                    && mapper.TryGetMappingType(parameters[i].ParameterType, out var mappingType))
                {
                    var mappingInst = _services.GetRequiredService(mappingType);

                    var mapTask = (Task)map(mappingInst, new object[] { context, inputs.Span[i] });

                    var mappedType = await mapTask.ConvertAsync().ConfigureAwait(false);
                    inputBuffer[i] = mappedType;
                }
                else
                {
                    throw new ArgumentException($"There is no registered mapping from {inputs.Span[i]} to type {parameters[i].ParameterType}");
                }
            }

            return inputBuffer;
        }
    }
}
