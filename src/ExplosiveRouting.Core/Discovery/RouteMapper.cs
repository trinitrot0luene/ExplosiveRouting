﻿using ExplosiveRouting.Extensions;
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

        public bool TryGetRoute(string[] path, out Route value, bool throwOnAmbigious = false, StringComparison comparisonStrategy = StringComparison.Ordinal)
        {
            value = FindRecurse(path, 0, throwOnAmbigious, comparisonStrategy);

            return value != null;
        }

        public void AddRoute(Type containingType)
        {
            if (!IsValidController(containingType))
                throw new ArgumentException("Your controller must extend the RouteController class.");

            AddNode(null, containingType);
        }

        private Route FindRecurse(string[] path, int currPos, bool throwOnAmbigious = false, StringComparison comparisonStrategy = StringComparison.Ordinal, List<RouteNode> previousNodes = null)
        {
            var nodes = Match(previousNodes, path[currPos], comparisonStrategy);

            if (currPos > path.Length)
                return null;

            if (nodes.Count == 0)
            {
                return null;
            }
            else if (nodes.Count == 1)
            {
                if (nodes[0] is Route route)
                {
                    var isPossible = RouteIsPossible(path.Length - currPos, route);

                    return isPossible ? route : null;
                }
                else
                {
                    goto Next;
                }
            }

            var routes = nodes.FindAll(n => n is Route r && RouteIsPossible(path.Length - currPos, r));

            if (routes.Count > 1)
            {
                if (throwOnAmbigious)
                    throw new Exception("Multiple routes matched this input.");
                else
                    return null;
            }

        Next:

            return FindRecurse(path, ++currPos, throwOnAmbigious, comparisonStrategy, nodes);
        }

        private List<RouteNode> Match(List<RouteNode> source, string path, StringComparison comparisonStrategy)
        {
            if (source == null)
            {
                return Root.Nodes.FindAll(n =>
                {
                    for (int i = 0; i < n.Routes.Length; i++)
                    {
                        if (string.Equals("", n.Routes[i]) || string.Equals(path, n.Routes[i], comparisonStrategy))
                            return true;
                    }

                    return false;
                });
            }
            else
            {
                var nodes = new List<RouteNode>();
                for (int i = 0; i < source.Count; i++)
                {
                    if (source[i].Next != null)
                    {
                        nodes.AddRange(source[i].Next.FindAll(n =>
                        {
                            for (int j = 0; j < n.Routes.Length; i++)
                            {
                                if (string.Equals("", n.Routes[i]) || string.Equals(path, n.Routes[i], comparisonStrategy))
                                    return true;
                            }

                            return false;
                        }));
                    }
                }

                return nodes;
            }
        }

        private bool RouteIsPossible(int remainingItems, Route targetRoute)
        {
            if (targetRoute.RequiredParamCount <= remainingItems)
                return true;

            return false;
        }

        private void AddNode(RouteNode parent, Type containingType)
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

            for (int i = 0; i < methods.Length; i++)
            {
                var routeAttr = methods[i].GetCustomAttribute<RouteAttribute>();
                if (routeAttr == null) continue;

                if (!typeof(Task).IsAssignableFrom(methods[i].ReturnType))
                    throw new ArgumentException("A route must return type Task.");

                var route = new Route()
                {
                    Routes = routeAttr.Routes,
                    Parameters = methods[i].GetParameters(),
                    Attributes = methods[i].GetCustomAttributes().ToArray(),
                    MethodInfo = methods[i],
                    Callback = methods[i].CreateCompiledInvocationDelegate(),
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
                AddNode(containingNode, type);
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
