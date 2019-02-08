using System;

namespace ExplosiveRouting.Shared
{
    /// <summary>
    /// A generic <see cref="IFailureResult"/> returned when there was an error preventing an operation from completing.
    /// </summary>
    public sealed class ErrorResult : IFailureResult
    {
        public string Message { get; }

        /// <summary>
        /// The <see cref="Exception"/> which caused the operation to be aborted.
        /// </summary>
        public Exception Exception { get; }

        public ErrorResult(string message = null, Exception error = null)
        {
        }
    }
}
