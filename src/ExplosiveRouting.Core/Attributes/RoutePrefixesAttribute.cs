using System;

namespace ExplosiveRouting.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class RoutePrefixesAttribute : Attribute
    {
        public string[] Prefixes { get; }

        public RoutePrefixesAttribute(params string[] prefixes)
        {
            Prefixes = prefixes;
        }
    }
}
