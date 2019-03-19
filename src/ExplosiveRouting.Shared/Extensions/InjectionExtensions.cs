using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplosiveRouting.Shared
{
    public static class InjectionExtensions
    {
        public static T CreateInstanceOf<T>(this Type type, IServiceProvider services)
        {
            var ctors = type.GetConstructors()
                .OrderByDescending(t => t.GetParameters().Length).ToArray();

            var parameters = new List<object>();
            for (int i = 0; i < ctors.Length; i++)
            {
                var paramsInfo = ctors[i].GetParameters();
                for (int j = 0; j < paramsInfo.Length; j++)
                {
                    var currentParam = paramsInfo[j];
                    var inst = services.GetService(currentParam.ParameterType);
                    if (inst == (currentParam.ParameterType.IsValueType ? Activator.CreateInstance(currentParam.ParameterType) : null) && !currentParam.IsOptional)
                        break;
                    parameters.Add(inst);
                }

                if (parameters.Count != paramsInfo.Length)
                    continue;
                else
                    break;
            }

            return (T)Activator.CreateInstance(type, parameters.ToArray());
        }
    }
}
