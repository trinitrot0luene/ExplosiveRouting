using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Shared
{
    /// <summary>
    /// A result returned when there was an error preventing an operation from completing.
    /// </summary>
    public interface IFailureResult : IResult
    {
        /// <summary>
        /// The <see cref="Exception"/> which caused the operation to be aborted.
        /// </summary>
        Exception Exception { get; }
    }
}
