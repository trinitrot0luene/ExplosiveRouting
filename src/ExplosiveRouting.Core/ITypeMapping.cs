using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveRouting
{
    public interface ITypeMapping<TType, TContext>
    {
        Task<TType> MapAsync(TContext context, string token);
    }
}
