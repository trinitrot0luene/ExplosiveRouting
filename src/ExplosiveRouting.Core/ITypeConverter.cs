using System;
using System.Threading.Tasks;

namespace ExplosiveRouting.Core
{
    public interface ITypeConverter<TContext>
    {
        Type TargetType { get; }

        ValueTask<IResult> Convert(TContext context);
    }

    public interface ITypeConverter
    {
    }
}