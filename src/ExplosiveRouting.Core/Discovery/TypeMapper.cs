using ExplosiveRouting.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExplosiveRouting.Discovery
{
    public sealed class TypeMapper : ITypeMapper
    {
        private readonly ConcurrentDictionary<Type, Func<object, object[], object>> _mappings;

        public TypeMapper()
        {
            _mappings = new ConcurrentDictionary<Type, Func<object, object[], object>>();
        }

        public void AddMapping(Assembly assembly)
        {
            var exportedTypes = assembly.GetExportedTypes();
            for (int i = 0; i < exportedTypes.Length; i++)
            {
                var ifaceImpl = exportedTypes[i]
                    .GetInterfaces()
                    .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ITypeMapping<,>));

                if (ifaceImpl == null) continue;

                RegisterMap(ifaceImpl, exportedTypes[i]);
            }
        }

        public void AddMapping(Type mapperType)
        {
            var ifaceImpl = mapperType
                .GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITypeMapping<,>));

            if (ifaceImpl == null)
                throw new ArgumentException("Your mapper must implement the ITypeMapping interface.");

            RegisterMap(ifaceImpl, mapperType);
        }

        private void RegisterMap(Type ifaceImpl, Type mapperType)
        {
            var callback = mapperType
                .GetMethod("MapAsync")
                .CreateCompiledInvocationDelegate();

            var targetType = ifaceImpl.GetGenericArguments()[0];

            _mappings[targetType] = callback;
        }

        public bool TryGetMapping(Type target, out Func<object, object[], object> mapping)
        {
            return _mappings.TryGetValue(target, out mapping);
        }
    }
}
