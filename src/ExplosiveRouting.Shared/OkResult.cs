using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Shared
{
    public sealed class OkResult : IResult
    {
        public string Message { get; }

        public OkResult(string message)
        {
            Message = message;
        }
    }
}
