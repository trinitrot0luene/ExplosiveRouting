using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveRouting.Discovery
{
    public abstract class RouteController<TContext>
    {
        public TContext Context { get; set; }

        public virtual ValueTask OnBeforeExecute() => new ValueTask();

        public virtual ValueTask OnAfterExecute() => new ValueTask();
    }
}
