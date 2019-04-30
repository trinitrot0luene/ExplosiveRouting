using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExplosiveRouting
{
    public interface ITypeMapper
    {
        void AddMapping(Type mappingType, IServiceCollection services);

        void AddMapping(Assembly assembly, IServiceCollection services);

        bool TryGetMapping(Type targetType, out Func<object, object[], object> mapping);

        bool TryGetMappingType(Type target, out Type mappingType);
    }
}
