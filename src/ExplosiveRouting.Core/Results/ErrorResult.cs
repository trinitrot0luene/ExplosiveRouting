using System;

namespace ExplosiveRouting.Core
{
    /// <summary>
    /// A generic <see cref="IFailureResult"/> returned when there was an error preventing an operation from completing.
    /// </summary>
    public sealed class ErrorResult : IFailureResult
    {
        /// <summary>
        /// Gets the error message of the result.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the <see cref="Exception"/> which caused the operation to be aborted.
        /// </summary>
        public Exception Exception { get; }

        public ErrorResult(string message = null, Exception error = null)
        {
        }
    }
}
