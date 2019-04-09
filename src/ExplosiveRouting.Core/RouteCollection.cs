using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveRouting.Core
{
    /// <summary>
    /// Contains a collection of <see cref="Route"/>s
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class RouteCollection<TContext> where TContext : IContext
    {
        public virtual Task OnExecuteAsync() => Task.CompletedTask;

        public virtual Task AfterExecuteAsync() => Task.CompletedTask;

        public virtual void OnExecute() { }

        public virtual void AfterExecute() { }
    }
}
