using System;

namespace ExplosiveRouting.Core
{
    public static class ConversionResult
    {
        public class ConversionSuccessResult : ISuccessResult
        {
            public object Result { get; }

            public string Message { get; }

            internal ConversionSuccessResult(object result, string message)
            {
                this.Result = result;
                this.Message = message;
            }
        }

        public static ISuccessResult FromSuccess(object result, string message = null) => new ConversionSuccessResult(result, message);

        public static IFailureResult FromFailure(string message = null, Exception exception = null) => new ErrorResult(message, exception);
    }
}