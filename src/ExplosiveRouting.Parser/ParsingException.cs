using System;
using System.Runtime.Serialization;

namespace ExplosiveRouting.Parser
{
    /// <summary>
    /// Thrown when there was an error in the string supplied to an <see cref="IParser"/>.
    /// </summary>
    [Serializable]
    public class ParsingException : Exception
    {
        internal ParsingException()
        {
        }

        internal ParsingException(string message) : base(message)
        {
        }

        internal ParsingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParsingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}