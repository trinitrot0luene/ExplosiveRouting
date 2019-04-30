using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExplosiveRouting.Discovery
{
    public interface ITypeMapper
    {
        void AddMapping(Type mappingType);

        void AddMapping(Assembly assembly);

        bool TryGetMapping(Type targetType, out Func<object, object[], object> mapping);
    }
}
