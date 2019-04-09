using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Core
{
    public sealed class AggregateResult : IResult
    {
        public string Message { get; }

        public IReadOnlyCollection<IResult> Results { get; }

        public bool IsSuccess
        {
            get
            {
                foreach (var result in Results)
                    if (result is IFailureResult)
                        return false;
                return true;
            }
        }

        public AggregateResult(string message, IReadOnlyCollection<IResult> results)
        {
            Message = message;
            Results = results;
        }

        public AggregateResult(IReadOnlyCollection<IResult> results)
        {
            Results = results;
        }
    }
}
