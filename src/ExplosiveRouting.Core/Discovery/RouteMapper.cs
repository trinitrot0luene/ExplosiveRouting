using ExplosiveRouting.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExplosiveRouting.Discovery
{
    public class RouteMapper<TContext> : IRouteMapper<TContext>
    {
        public RouteRoot Root { get; } = new RouteRoot();

        public bool TryGetRoute(string[] path, out (Route, int) value, bool throwOnAmbigious = false, StringComparison comparisonStrategy = StringComparison.Ordinal)
        {

            value = FindRecurse();

            return value != (null, default);
        }

        public void AddRoute(Type containingType, IServiceCollection services)
        {
            if (!IsValidController(containingType))
                throw new ArgumentException("Your controller must extend the RouteController class.");

            AddNode(null, containingType, services);
        }

        public void AddRoute(Assembly assembly, IServiceCollection services)
        {
            foreach (var type in assembly.GetExportedTypes().Where(t => IsValidController(t) && !t.IsNested))
            {
                AddNode(null, type, services);
            }
        }

        private Route FindRecurse(ref int counter, string[] tokens, List<RouteNode> lastNodes = null)
        {
            if (tokens.Length - counter < 1)
            {
                throw new NotImplementedException("Handle this.");
            }

            var currentString = tokens[counter++];

            var currentNodes = (lastNodes ?? Root.Nodes).FindAll(n => MatchRoute(n, currentString));

            for (int i = 0; i < currentNodes.Count; i++)
            {
                if (currentNodes[i] is Route route)
                {
                    if (ValidateRoute(tokens.AsSpan().Slice(counter), route))
                        return route;
                    else
                        currentNodes.Remove(currentNodes[i]);
                }
            }

            return FindRecurse(ref counter, tokens, currentNodes);
        }

        private bool ValidateRoute(Span<string> tokens, Route route)
        {
            var parameters = route.Parameters;
            for (int i = 0; i < route.Parameters.Length; i++)
            {
                if (parameters[i].IsOptional)
                {                                                                                     
                }
                else
                {
                    if (tokens)
                }
            }
        }

        private bool MatchRoute(RouteNode n, string currentString)
        {
            for (int i = 0; i < n.Routes.Length; i++)
                if (string.Equals("", n.Routes[i]) || string.Equals(currentString, n.Routes[i]))
                    return true;

            return false;
        }

        private bool RouteIsPossible(int tokensLeft, Route route)
        {
            for (int i = 0; i  < route.Parameters.Length; i++)
            {
                if (route.Parameters[i].IsOptional)
                    return true;
                else if (tokensLeft == 0)
                    return false;

                --tokensLeft;
            }

            return tokensLeft == 0;
        }

        private void AddNode(RouteNode parent, Type containingType, IServiceCollection services)
        {
            var controllerRouteAttr = containingType.GetCustomAttribute<RouteAttribute>();

            var containingNode = controllerRouteAttr == null ?
                default(RouteNode) :
                new RouteNode()
                {
                    Routes = controllerRouteAttr.Routes
                };

            if (containingNode != null)
            {
                if (parent != null)
                    parent.Next.Add(containingNode);
                else
                    Root.Nodes.Add(containingNode);
            }

            var methods = containingType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var controllerAttr = containingType.GetCustomAttribute<ControllerAttribute>() ?? new ControllerAttribute();

            for (int i = 0; i < methods.Length; i++)
            {
                var routeAttr = methods[i].GetCustomAttribute<RouteAttribute>();
                if (routeAttr == null) continue;

                if (!typeof(Task).IsAssignableFrom(methods[i].ReturnType))
                    throw new ArgumentException("A route must have return type of Task.");

                switch (controllerAttr.ServiceLifetime)
                {
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(containingType);
                        break;
                    case ServiceLifetime.Scoped:
                        services.AddScoped(containingType);
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(containingType);
                        break;
                }

                var route = new Route()
                {
                    Routes     = routeAttr.Routes,
                    RunMode    = routeAttr.RunMode,
                    Parameters = methods[i].GetParameters(),
                    Attributes = methods[i].GetCustomAttributes().ToArray(),
                    MethodInfo = methods[i],
                    Callback   = methods[i].CreateCompiledInvocationDelegate(),
                    Next = null
                };

                if (containingNode != null)
                    containingNode.Next.Add(route);
                else if (parent != null)
                    parent.Next.Add(route);
                else
                    Root.Nodes.Add(route);
            }

            foreach (var type in containingType.GetNestedTypes().Where(t => IsValidController(t)))
                AddNode(containingNode, type, services);
        }

        private bool IsValidController(Type containingType)
        {
            Type currentType = containingType.BaseType;

            if (currentType == null) return false;

            while (currentType.BaseType != null)
            {
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == typeof(RouteController<>))
                    return true;

                currentType = currentType.BaseType;
            }

            return false;
        }
    }
}
