using ExplosiveRouting.Extensions;
using Microsoft.Extensions.DependencyInjection;
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

        private readonly ConcurrentDictionary<Type, Type> _mappingTypes;

        public TypeMapper()
        {
            _mappings = new ConcurrentDictionary<Type, Func<object, object[], object>>();
            _mappingTypes = new ConcurrentDictionary<Type, Type>();
        }

        public void AddMapping(Assembly assembly, IServiceCollection services)
        {
            var exportedTypes = assembly.GetExportedTypes();
            for (int i = 0; i < exportedTypes.Length; i++)
            {
                var ifaceImpl = exportedTypes[i]
                    .GetInterfaces()
                    .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ITypeMapping<,>));

                if (ifaceImpl == null) continue;

                RegisterMap(ifaceImpl, exportedTypes[i], services);
            }
        }

        public void AddMapping(Type mapperType, IServiceCollection services)
        {
            var ifaceImpl = mapperType
                .GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITypeMapping<,>));

            if (ifaceImpl == null)
                throw new ArgumentException("Your mapper must implement the ITypeMapping interface.");

            RegisterMap(ifaceImpl, mapperType, services);
        }

        private void RegisterMap(Type ifaceImpl, Type mapperType, IServiceCollection services)
        {
            var callback = mapperType
                .GetMethod("MapAsync")
                .CreateCompiledInvocationDelegate();

            var targetType = ifaceImpl.GetGenericArguments()[0];

            services.AddSingleton(mapperType);

            _mappingTypes[targetType] = mapperType;
            _mappings[targetType] = callback;
        }

        public bool TryGetMapping(Type target, out Func<object, object[], object> mapping)
        {
            return _mappings.TryGetValue(target, out mapping);
        }

        public bool TryGetMappingType(Type target, out Type mappingtype)
        {
            return _mappingTypes.TryGetValue(target, out mappingtype);
        }
    }
}
