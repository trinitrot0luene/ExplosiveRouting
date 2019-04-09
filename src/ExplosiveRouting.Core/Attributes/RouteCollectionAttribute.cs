using System;

namespace ExplosiveRouting.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class RouteCollectionAttribute : Attribute
    {
        public string[] Prefixes { get; }

        public RouteCollectionAttribute(params string[] prefixes)
        {
            Prefixes = prefixes;
        }
    }
}
